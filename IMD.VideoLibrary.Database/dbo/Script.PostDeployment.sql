
--Post deployment

INSERT INTO VideoReel(Name, Description, VideoDefinition, VideoStandard, TotalDuration) SELECT 'PAL HD Video', 'PAL standard HD Video', 2, 1, '00:00:38:11'
INSERT INTO VideoReel(Name, Description, VideoDefinition, VideoStandard, TotalDuration) SELECT 'PAL SD Video', 'PAL standard SD Video', 1, 1, '00:02:11:01'
INSERT INTO VideoReel(Name, Description, VideoDefinition, VideoStandard, TotalDuration) SELECT 'NTSC HD Video', 'NTSC standard HD Video', 2, 2, '00:00:54:08'
INSERT INTO VideoReel(Name, Description, VideoDefinition, VideoStandard, TotalDuration) SELECT 'NTSC SD Video', 'NTSC standard SD Video', 1, 2, '00:00:30:00'

INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Bud Light', 'A factory is working on the new Bud Light Platinum', 1, 1, '00:00:00:00', '00:00:30:12'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'M&M''s', 'At a party, a brown-shelled M&M is mistaken for being naked. As a result, the red M&M tears off its skin and dances to "Sexy and I Know It" by LMFAO', 1, 2, '00:00:00:00', '00:00:15:27'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Audi', 'A group of vampires are having a party in the woods. The vampire in charge of drinks (blood types) arrives in his Audi. The bright lights of the car kills all of the vampires, with him wondering where everyone went afterwards.', 1, 1, '00:00:00:00', '00:01:30:00'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Chrysler', 'Clint Eastwood recounts how the automotive industry survived the Great Recession.', 1, 1, '00:00:00:00', '00:00:10:14'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Fiat', 'A man walks through a street to discover a beautiful woman (Catrinel Menghia) standing on a parking space, who proceeds to approach and seduce him, when successfully doing so he then discovered he was about to kiss a Fiat 500 Abarth.', 1, 2, '00:00:00:00', '00:00:18:11'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Pepsi', 'People in the Middles Ages try to entertain their king (Elton John) for a Pepsi. While the first person fails, a mysterious person (Season 1 X Factor winner Melanie Amaro) wins the Pepsi by singing Aretha Franklin''s "Respect"." After she wins, she overthrows the king and gives Pepsi to all the town.', 1, 2, '00:00:00:00', '00:00:20:00'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Best Buy', 'An ad featuring the creators of the cameraphone, Siri, and the first text message. The creators of Words with Friends also appear parodying the incident involving Alec Baldwin playing the game on an airplane.', 2, 1, '00:00:00:00', '00:00:10:05'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Captain America: The First Avenger', 'Video Promo', 2, 1, '00:00:00:00', '00:00:20:10'
INSERT INTO VideoClip(Name, Description, VideoDefinition, VideoStandard, StartTime, EndTime) SELECT 'Volkswagen "Black Beetle"', 'A computer-generated black beetle runs fast, as it is referencing the new Volkswagen model.', 2, 2, '00:00:00:00', '00:00:30:00'

--PAL SD Video/ clips
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 2, 1
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 2, 3
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 2, 4
--PAL HD Video/ clips
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 1, 7
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 1, 8
--NTSC HD Video/ clips
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 3, 9
--NTSC SD Video/ clips
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 4, 5
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 4, 6
INSERT INTO VideoReelVideoClipLink (VideoReelId, VideoClipId) SELECT 4, 2


