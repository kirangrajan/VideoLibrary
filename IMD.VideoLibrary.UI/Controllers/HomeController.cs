using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IMD.VideoLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVideoReelListViewModel _videoReelListViewModel;
        private readonly IVideoReelAddViewModel _videoReelAddViewModel;

        public HomeController(IVideoReelListViewModel videoReelListViewModel, IVideoReelAddViewModel videoReelAddViewModel)
        {
            this._videoReelAddViewModel = videoReelAddViewModel;
            this._videoReelListViewModel = videoReelListViewModel;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a POC created by Kiran as part of a Technical evaluation.";

            return View();
        }

        /// <summary>
        /// List all video reels
        /// </summary>
        /// <returns>Action result</returns>
        public ActionResult GetVideoReels()
        {
            IList<Models.VideoReel> uiVideoReels = null;
            try
            {
                var videoReels = this._videoReelListViewModel.ListAll();
                uiVideoReels = this.MapFromDomainVideoReels(videoReels);
            }
            catch
            {
                // Proper exception handling to be done
            }

            return Json(uiVideoReels, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lists all video clips
        /// </summary>
        /// <returns>Action result</returns>
        public ActionResult GetVideoClips()
        {
            IList<Models.VideoClip> uiVideoClips = null;
            try
            {
                uiVideoClips = this.MapFromDomainVideoClips(this._videoReelListViewModel.ListAllClips());
            }
            catch
            {
                // Proper exception handling to be done
            }

            return Json(uiVideoClips, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Save a Video Reel
        /// </summary>
        /// <param name="videoReel">video reel to be saved</param>
        /// <returns>Json Result</returns>
        public ActionResult SaveVideoReel(Models.VideoReel videoReel)
        {
            IList<Models.VideoReel> uiVideoReels = null;
            try
            {
                var domainVideoReel = this.MapFromUIVideoReels(new List<Models.VideoReel> { videoReel })[0];

                this._videoReelListViewModel.ModifyReel(domainVideoReel);

                uiVideoReels = this.MapFromDomainVideoReels(this._videoReelListViewModel.ListAll());

                if (this._videoReelAddViewModel.ErrorMessage.Length > 0)
                {
                    var videoReelModified = uiVideoReels.ToList().Find(p => p.Id == videoReel.Id);
                    videoReelModified.ErrorMessage = this._videoReelAddViewModel.ErrorMessage;
                }
            }
            catch
            {
                // Proper exception handling to be done
            }

            return Json(uiVideoReels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddClipToVideoReel(Models.VideoReel videoReel)
        {
            IList<Models.VideoReel> uiVideoReels = null;
            try
            {
                var domainVideoReel = this.MapFromUIVideoReels(new List<Models.VideoReel> { videoReel })[0];

                this._videoReelAddViewModel.AddClipToReel(domainVideoReel, videoReel.SelectedVideoClipId);

                uiVideoReels = this.MapFromDomainVideoReels(this._videoReelListViewModel.ListAll());
                if (this._videoReelAddViewModel.ErrorMessage.Length > 0)
                {
                    var videoReelModified = uiVideoReels.ToList().Find(p => p.Id == videoReel.Id);
                    videoReelModified.ErrorMessage = this._videoReelAddViewModel.ErrorMessage;
                }
            }
            catch
            {
                // Proper exception handling to be done
            }

            return Json(uiVideoReels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteClipFromVideoReel(Models.VideoReel videoReel)
        {
            IList<Models.VideoReel> uiVideoReels = null;
            try
            {
                var domainVideoReel = this.MapFromUIVideoReels(new List<Models.VideoReel> { videoReel })[0];

                this._videoReelAddViewModel.RemoveClipFromReel(domainVideoReel, videoReel.SelectedVideoClipId);

                uiVideoReels = this.MapFromDomainVideoReels(this._videoReelListViewModel.ListAll());
                if (this._videoReelAddViewModel.ErrorMessage.Length > 0)
                {
                    var videoReelModified = uiVideoReels.ToList().Find(p => p.Id == videoReel.Id);
                    videoReelModified.ErrorMessage = this._videoReelAddViewModel.ErrorMessage;
                }
            }
            catch
            {
                // Proper exception handling to be done
            }

            return Json(uiVideoReels, JsonRequestBehavior.AllowGet);
        }

        private IList<Models.VideoReel> MapFromDomainVideoReels(IList<VideoReel> videoReels)
        {
            if (videoReels == null)
            {
                return null;
            }

            var videoclips = this._videoReelListViewModel.ListAllClips();

            var uiVideoReels = new List<Models.VideoReel>();
            foreach (var videoReel in videoReels)
            {
                uiVideoReels.Add(new Models.VideoReel()
                {
                    Id = videoReel.Id,
                    Description = videoReel.Description,
                    Name = videoReel.Name,
                    TotalDuration = videoReel.TotalDuration,
                    VideoClips = this.MapFromDomainVideoClips(videoclips),
                    VideoDefinition = videoReel.VideoDefinition.ToString(),
                    VideoStandard = videoReel.VideoStandard.ToString(),
                    VideoReelVideoClips = this.MapFromDomainVideoClips(videoReel.VideoClips)
                });
            }

            return uiVideoReels;
        }

        private IList<VideoReel> MapFromUIVideoReels(IList<Models.VideoReel> videoReels)
        {
            if (videoReels == null)
            {
                return null;
            }


            var domainVideoReels = new List<VideoReel>();
            foreach (var videoReel in videoReels)
            {
                domainVideoReels.Add(new VideoReel()
                {
                    Id = videoReel.Id,
                    Description = videoReel.Description,
                    Name = videoReel.Name,
                    TotalDuration = videoReel.TotalDuration,
                    VideoDefinition = (VideoDefinition)System.Enum.Parse(typeof(VideoDefinition), videoReel.VideoDefinition),
                    VideoStandard = (VideoStandard)System.Enum.Parse(typeof(VideoStandard), videoReel.VideoStandard),

                });
            }

            return domainVideoReels;
        }

        private IList<Models.VideoClip> MapFromDomainVideoClips(IList<VideoClip> videoClips)
        {
            if (videoClips == null)
            {
                return null;
            }


            var uiVideoClips = new List<Models.VideoClip>();
            foreach (var videoClip in videoClips)
            {
                uiVideoClips.Add(new Models.VideoClip()
                {
                    Id = videoClip.Id,
                    Description = videoClip.Description,
                    Name = videoClip.Name,
                    StartTime = videoClip.StartTime,
                    EndTime = videoClip.EndTime,
                    VideoDefinition = videoClip.VideoDefinition.ToString(),
                    VideoStandard = videoClip.VideoStandard.ToString(),
                });
            }

            return uiVideoClips;
        }
    }
}