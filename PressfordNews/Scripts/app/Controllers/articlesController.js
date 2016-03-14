(function () {
    'use strict';

    angular
        .module('PressfordNewsApp')
        .controller('articlesController', articlesController);

    articlesController.$inject = ['$scope', 'articleServices'];

    function articlesController($scope, articleServices) {
        $scope.articles = articleServices.query();
    }
})();
