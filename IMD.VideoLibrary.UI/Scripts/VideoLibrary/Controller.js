videoReelApp.controller("videoReelController", function ($scope, videoReelService) {

    // Load all Video Reels on page load
    getAllVideoReels();

    //To Get all book records  
    function getAllVideoReels() {
        var getVideoReels = videoReelService.getVideoReels();
        getVideoReels.then(function (videoReels) {
            $scope.videoReels = videoReels.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    // Save Video Reel details
    $scope.saveVideoReel = function (videoReel) {
        var getVideoReel = videoReelService.saveVideoReel(videoReel);
        getVideoReel.then(function (videoReels) {
            $scope.videoReels = videoReels.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    // Add clip to video reel
    $scope.addVideoClipToVideoReel = function (videoReel) {
        
        var getVideoReels = videoReelService.addVideoClipToVideoReel(videoReel);
        getVideoReels.then(function (videoReels) {
            $scope.videoReels = videoReels.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    // Delete clip from Video Reel
    $scope.deleteVideoClipFromVideoReel = function (videoReel, videoClip) {
        
        videoReel.SelectedVideoClipId = videoClip.Id;
        var getVideoReels = videoReelService.deleteVideoClipFromVideoReel(videoReel);
        getVideoReels.then(function (videoReels) {
            $scope.videoReels = videoReels.data;
        }, function () {
            alert('Error in getting records');
        });
    }
});