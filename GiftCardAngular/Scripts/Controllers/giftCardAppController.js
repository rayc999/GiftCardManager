// Top-level controller
angular.module("giftCardApp")
    .controller("giftCardAppController", GiftCardAppController);

// Dependency injection
GiftCardAppController.$inject = ['$scope', '$http'];

function GiftCardAppController($scope, $http) {

    var model = {};

    $scope.data = model;
    $scope.displayMode = "list";
    $scope.currentGiftCard = null;

    model.items = $http({
        method: "GET",
        url: "/GiftCard/GetGiftCards"
    }).then(function successCallback(response) {
        model.items = response.data;
    }, function errorCallback(response) {
        var message = response.data;
    });

    // Count the number of incomplete items
    $scope.giftCardCount = function () {
        var count = 0;
        angular.forEach($scope.data.items, function (item) {
            count++;
        });
        return count;
    }

    // Apply different class based on the number of incomplete items
    $scope.warningLevel = function () {
        return $scope.giftCardCount() < 4 ? "label-success" : "label-warning";
    }

    // Used when use clicks the Add button
    $scope.addNewItem = function (actionText) {
        $scope.data.items.push({ action: actionText, done: false });
    }

    $scope.editGiftCard = function (giftCard) {
        $scope.currentGiftCard = giftCard ? angular.copy(giftCard) : {};
        $scope.displayMode = "edit";
    }
}
