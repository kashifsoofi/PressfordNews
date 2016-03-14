(function () {
    'use strict';

    var articleServicesProvider = angular.module('articleServicesProvider', ['ngResource']);

    articleServicesProvider.factory('articleServices', ['$resource',
      function ($resource) {
          return $resource('/api/articles', {}, {
                      query: { method: 'GET', params: { }, isArray: true
          }
      });
}]);
})();