videoReelApp.service("videoReelService", function ($http) {
   
    //get All Video Reels
    this.getVideoReels = function () {
        return $http.get("Home/GetVideoReels");
    };

    //get video clips
    this.getVideoClips = function () {
        return $http.get("Home/GetVideoClips");
    };


    this.saveVideoReel = function (videoReel) {
        var updatedVideoReels = $http({
            method: "post",
            url: "Home/SaveVideoReel",
            data: JSON.stringify(videoReel),
            dataType: "json"
        });

        return updatedVideoReels;
    }

    this.addVideoClipToVideoReel = function (videoReel) {
        
        var updatedVideoReels = $http({
            method: "post",
            url: "Home/AddClipToVideoReel",
            data: JSON.stringify(videoReel),
            dataType: "json"
        });

        return updatedVideoReels;
    }

    this.deleteVideoClipFromVideoReel = function (videoReel) {
        var updatedVideoReels = $http({
            method: "post",
            url: "Home/DeleteClipFromVideoReel",
            data: JSON.stringify(videoReel),
            dataType: "json"
        });

        return updatedVideoReels;
    }
});