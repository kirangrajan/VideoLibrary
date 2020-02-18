using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.ViewModel.Test
{
    public static class DataHelper
    {
        public static VideoClip GetaPALSDVideoClip()
        {
            return new VideoClip()
            {
                Id = 1,
                Name = "Bud Light",
                Description = "A factory is working on the new Bud Light Platinum.",
                VideoStandard = VideoStandard.PAL,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:30:12"
            };
        }

        public static VideoClip GetaPALSDVideoClipB()
        {
            return new VideoClip()
            {
                Id = 5,
                Name = "Audi",
                Description = "A group of vampires are having a party in the woods. The vampire in charge of drinks (blood types) arrives in his Audi. The bright lights of the car kills all of the vampires, with him wondering where everyone went afterwards.",
                VideoStandard = VideoStandard.PAL,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:01:30:00"
            };
        }

        public static VideoClip GetaPALSDVideoClipC()
        {
            return new VideoClip()
            {
                Id = 6,
                Name = "Chrysler",
                Description = "Clint Eastwood recounts how the automotive industry survived the Great Recession.",
                VideoStandard = VideoStandard.PAL,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:10:14"
            };
        }

        public static VideoClip GetaNTSCSDVideoClip()
        {
            return new VideoClip()
            {
                Id = 2,
                Name = "M&M's",
                Description = "It a party, a brown-shelled M&M is mistaken for being naked. As a result, the red M&M tears off its skin and dances to \"Sexy and I Know It\" by LMFAO",
                VideoStandard = VideoStandard.NTSC,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:15:27"
            };
        }

        public static VideoClip GetaPALHDVideoClip()
        {
            return new VideoClip()
            {
                Id = 3,
                Name = "Captain America: The First Avenger",
                Description = "Video Promo",
                VideoStandard = VideoStandard.PAL,
                VideoDefinition = VideoDefinition.HD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:20:10"
            };
        }

        public static VideoClip GetaNTSCHDVideoClip()
        {
            return new VideoClip()
            {
                Id = 4,
                Name = "Volkswagen \"Black Beetle\"",
                Description =
                    "A computer-generated black beetle runs fast, as it is referencing the new Volkswagen model",
                VideoStandard = VideoStandard.NTSC,
                VideoDefinition = VideoDefinition.HD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:30:00"
            };
        }

        public static VideoClip GetaNTSCSDVideoClipB()
        {
            return new VideoClip()
            {
                Id = 7,
                Name = "Fiat",
                Description = "A man walks through a street to discover a beautiful woman (Catrinel Menghia) standing on a parking space, who proceeds to approach and seduce him, when successfully doing so he then discovered he was about to kiss a Fiat 500 Abarth.",
                VideoStandard = VideoStandard.NTSC,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:18:11"
            };
        }

        public static VideoClip GetaNTSCSDVideoClipC()
        {
            return new VideoClip()
            {
                Id = 8,
                Name = "Pepsi",
                Description = "People in the Middles Ages try to entertain their king (Elton John) for a Pepsi. While the first person fails, a mysterious person (Season 1 X Factor winner Melanie Amaro) wins the Pepsi by singing Aretha Franklin's \"Respect\".\" After she wins, she overthrows the king and gives Pepsi to all the town.",
                VideoStandard = VideoStandard.NTSC,
                VideoDefinition = VideoDefinition.SD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:20:00"
            };
        }
    }
}
