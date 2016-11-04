'use strict'

// Angular
var app = angular.module('app', ['ngMaterial', 'ngResource'])

// ReactionAPIクライアント
app.factory('reactions', ['$resource', function ($resource) {
    return $resource('api/reactions/:id', { id: '@id' },
        {
            // PUTメソッドを追加
            'update': { method:'PUT' }
        }
    )
}])

app.controller('appController', function ($scope, $resource, $mdDialog, $filter, reactions) {
    // Reaction設定一覧を取得します。
    $scope.refresh = function () {
        $scope.reactions = reactions.query()
    }

    // 新規Reaction設定を登録します。登録できたらリストがリフレッシュされます。
    $scope.create = function (newWord, newEmoji) {
        var newReaction = new reactions({ word: newWord, emoji: newEmoji })
        newReaction.$save(function (result) {
            $scope.refresh()
        })

        // ダイアログを消去
        $scope.newWord = ''
        $scope.newEmoji = ''
        $mdDialog.hide()
    }

    // 既存Reaction設定の変更を送ります。
    $scope.update = function (reaction) {
        reaction.$update(function (result) {
            console.log('Update')
        })
    }

    // Reaction設定を削除します。
    $scope.delete = function (reaction) {
        reaction.$delete(function (result) {
            console.log('Deleted')
            $scope.refresh()
        })
    }

    // 新規作成ダイアログを表示します。
    $scope.newDialog = function () {
        $mdDialog.show({
            contentElement: '#newDialog',
            escapeToClose: true
        })
    }

    // 表示されたダイアログを閉じます。
    $scope.dialogClose = function () {
        $mdDialog.cancel()
    }

    // Reaction設定一覧を取得
    $scope.refresh()

    // Custom Emoji一覧を取得
    $resource('api/emoji').get(function (result) {
        // デフォルト絵文字にカスタム絵文字を追加
        angular.extend(result, defaultEmoji)
        $scope.emoji = result
        $scope.emojiNames = Object.keys(result).filter(function (key) {
            return key !== '$promise' && key !== '$resolved'
        })
    })
})
