using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OverReaction.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OverReaction.Controllers
{
    /// <summary>
    /// Slack Reaction 設定API
    /// </summary>
    [Route("api/[controller]")]
    public class ReactionsController : Controller
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReactionsController()
        {
            using (var db = new ReactionContext())
            {
                db.Initialize();
            }
        }

        /// <summary>
        /// Reaction設定一覧を取得します。
        /// </summary>
        /// <returns>Reaction設定</returns>
        [HttpGet]
        public List<Reaction> GetAll()
        {
            using (var db = new ReactionContext())
            {
                return db.Reactions.ToList();
            }
        }

        /// <summary>
        /// 新規Reaction設定を登録します。
        /// </summary>
        /// <param name="reaction">Reaction設定</param>
        /// <returns>登録したReaction設定</returns>
        [HttpPost]
        public async Task<Reaction> Post([FromBody]Reaction reaction)
        {
            using (var db = new ReactionContext())
            {
                db.Reactions.Add(reaction);
                await db.SaveChangesAsync();

                return reaction;
            }
        }

        /// <summary>
        /// 検索ワードと絵文字の設定を更新します。
        /// </summary>
        /// <param name="id">更新するID</param>
        /// <param name="newReaction">新しい検索ワードと絵文字</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<Reaction> Update(int id, [FromBody]Reaction newReaction)
        {
            using (var db = new ReactionContext())
            {
                var oldReaction = db.Reactions.Single(reaction => reaction.Id == id);
                oldReaction.Word = newReaction.Word;
                oldReaction.Emoji = newReaction.Emoji;
                await db.SaveChangesAsync();

                return oldReaction;
            }
        }

        /// <summary>
        /// 指定した設定を削除します。
        /// </summary>
        /// <param name="id">削除するID</param>
        /// <returns>削除するIDがない場合は404</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (var db = new ReactionContext())
            {
                var deleteReaction = db.Reactions.FirstOrDefault(reaction => reaction.Id == id);
                if (deleteReaction != null)
                {
                    db.Reactions.Remove(deleteReaction);
                    await db.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
