using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OverReaction.Models
{
    /// <summary>
    /// Slack Reaction 設定モデル
    /// </summary>
    public class Reaction
    {
        /// <summary>
        /// ID(登録順連番)
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 検索ワード
        /// </summary>
        [Required]
        public string Word { get; set; }
        /// <summary>
        /// 絵文字
        /// </summary>
        [Required]
        public string Emoji { get; set; }
    }

    /// <summary>
    /// データベースコンテキスト
    /// </summary>
    public class ReactionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new SqliteConnectionStringBuilder { DataSource = "overreaction.sqlite" }.ToString();
            optionsBuilder.UseSqlite(connectionString);
        }

        /// <summary>
        /// Slack Reaction データベース
        /// </summary>
        public DbSet<Reaction> Reactions { get; set; }

        /// <summary>
        /// データベースにテーブルがなければ作成し、カラムに変更があればマイグレーションを実行します。変更がない場合は何もしません。
        /// </summary>
        public void Initialize()
        {
            // Database initialize
            if (!Database.EnsureCreated())
            {
                Database.Migrate();
            }
        }
    }
}
