using System.Text.Json;

namespace Vanessave.Shared.Services;

public class AchievementMetadataProvider
{
    public Dictionary<int, AchievementMetadata> AchievementsMetadata { get; }

    private const string AchievementsMetadataJson =
        """
         [
           {
             "Id": 0,
             "Name": "Seek the Truth",
             "Description": "Begin a new game.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/7a2813a41f32891d4ee56ab701f82d0f82341e63.jpg"
           },
           {
             "Id": 1,
             "Name": "The Magic Zone",
             "Description": "Drop an arcane or holy crystal on the ground for the first time.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/cf8f4c725d1ef3b067b0339107fb47c1a673300e.jpg"
           },
           {
             "Id": 2,
             "Name": "No Chants Required",
             "Description": "Chant a spell within one second 6 times.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/519e9030c8128c8968a55ac561a59b8801fbd9a3.jpg"
           },
           {
             "Id": 3,
             "Name": "Melee Rockstar",
             "Description": "Use attack, dodge, or absorption to complete a spellchant 30 times.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/4d4fad94859f2bfb6bdd0fc94f99bfa92202c13f.jpg"
           },
           {
             "Id": 4,
             "Name": "Magical Reaction",
             "Description": "Use absorption to absorb 3,000 Mana.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/5a94b27ea0a4efabde80b9de84d9de57df4392ba.jpg"
           },
           {
             "Id": 5,
             "Name": "Treasure Hunter",
             "Description": "Open 24 treasure chests in one round of the game.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/4c662fd66599bb7cd45314bcc096ada68a2030ed.jpg"
           },
           {
             "Id": 6,
             "Name": "Let There Be Light",
             "Description": "Illuminate all the lanterns in the Underground Cave.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/d85cb40f484c78157c9eb79d3f64f2087c6a6e14.jpg"
           },
           {
             "Id": 7,
             "Name": "Keep Your Hands Clean",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/6ec392e8e27a105be0a3570934b853d61ea659d7.jpg"
           },
           {
             "Id": 8,
             "Name": "Arcane Magic Scholar",
             "Description": "Reach Lv 3 of the Arcane element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/650c26196741877cfd9c608c664ee7d955dc69ec.jpg"
           },
           {
             "Id": 9,
             "Name": "Ice Magic Scholar",
             "Description": "Reach Lv 3 of the Ice element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/c2e32583b4415b47027d2d9d637b36cccc4e5fd4.jpg"
           },
           {
             "Id": 10,
             "Name": "Fire Magic Scholar",
             "Description": "Reach Lv 3 of the Fire element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/47b853747e6224e5dc4395f414568cedc8d23f19.jpg"
           },
           {
             "Id": 11,
             "Name": "Thunder Magic Scholar",
             "Description": "Reach Lv 3 of the Thunder element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/285f52c7cc73f12290243122a92c89fb3dc33ea1.jpg"
           },
           {
             "Id": 12,
             "Name": "Wind Magic Scholar",
             "Description": "Reach Lv 3 of the Wind element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/36a754df4941ab8c8f83f50bf2ce79f19cb0e1f6.jpg"
           },
           {
             "Id": 13,
             "Name": "Magic Ritual Scholar",
             "Description": "Reach Lv 3 of the Ritual of Magic Absorption.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/255a81a40096858f4aefe73613cb60ebf678ecf6.jpg"
           },
           {
             "Id": 14,
             "Name": "Bottomless Bag",
             "Description": "Expand your bag to the maximum.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/9c381d84c43ff43e0e98e18d2b6783aa94f1d261.jpg"
           },
           {
             "Id": 15,
             "Name": "True Aerial Expert",
             "Description": "Defeat 4 enemies in the air at once.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/b609bda80ee4b4f5b7672692dc9dcc9e6fc024c7.jpg"
           },
           {
             "Id": 16,
             "Name": "Oops! Did I Do That?",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/2c19d479a7ca393f8859cdc92d86dcd54f5d09d5.jpg"
           },
           {
             "Id": 17,
             "Name": "Mysterious Specter Armor",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/4589734eb389a579a0835de07e0ec9e11ef300c7.jpg"
           },
           {
             "Id": 18,
             "Name": "Crafted Soul, Ribbon Lover",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/143073030788e85bd7dc2585ad540a254f420283.jpg"
           },
           {
             "Id": 19,
             "Name": "Crafted Soul, Animal Lover",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/9446be06eb07e94d71e74055640141b89d4b5432.jpg"
           },
           {
             "Id": 20,
             "Name": "Enraged Specter Armor",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/3bad03a8974ad614f5ec9de5f1dc158d20b29eb6.jpg"
           },
           {
             "Id": 21,
             "Name": "Soul Doll of the Throne",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/b637ccb0288889cd0669493094930dd2a8af92dc.jpg"
           },
           {
             "Id": 22,
             "Name": "Crafted Soul of the Knight King",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/78b73cb2a24b8be05bc83193bc40cb24ccd8028f.jpg"
           },
           {
             "Id": 23,
             "Name": "Lost Crafted Soul",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/f8847ece41635205c146d075072625bfe8b6d565.jpg"
           },
           {
             "Id": 24,
             "Name": "Speed Demon",
             "Description": "Chant a spell within one second 60 times.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/5b70fea90f22e1287c6edfb2d4ea85ef48c686c8.jpg"
           },
           {
             "Id": 25,
             "Name": "Melee Master",
             "Description": "Use attack, dodge, or absorption to complete a spellchant 300 times.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/c796c05b699447cedaa6981bd243de94ead330fe.jpg"
           },
           {
             "Id": 26,
             "Name": "Divine Reaction",
             "Description": "Use absorption to absorb 30,000 Mana.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/27865209ce3bf5229dbefdff8e1c0f4a48011391.jpg"
           },
           {
             "Id": 27,
             "Name": "Treasure Master",
             "Description": "Open all treasure chests in one round of the game.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/2d5876aea5c2ccc94caac80db380a60537e5c981.jpg"
           },
           {
             "Id": 28,
             "Name": "Light the Way",
             "Description": "Remove all dark mist within the Dark Tunnel.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/2a1d550a5c800941931269b98d06d898fe149ea8.jpg"
           },
           {
             "Id": 29,
             "Name": "A Seal Broken",
             "Description": "Defeat the Seal in one attempt.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/5894117f73080250feed24e3a395bc6c097c6b9b.jpg"
           },
           {
             "Id": 30,
             "Name": "Master of Arcane",
             "Description": "Reach max level of the Arcane element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/68f53452ff6b4d96884a0f396786fbe3f336878f.jpg"
           },
           {
             "Id": 31,
             "Name": "Master of Ice",
             "Description": "Reach max level of the Ice element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/59b895c7dc2df5918c1b3fcd1b53996df96bed90.jpg"
           },
           {
             "Id": 32,
             "Name": "Master of Fire",
             "Description": "Reach max level of the Fire element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/53f5705bf571480a3938ab5c8ac0d2b026607b65.jpg"
           },
           {
             "Id": 33,
             "Name": "Master of Thunder",
             "Description": "Reach max level of the Thunder element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/a712468b8c06b644f2722def7cdc159fef56c110.jpg"
           },
           {
             "Id": 34,
             "Name": "Master of Wind",
             "Description": "Reach max level of the Wind element.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/170cba646a486fd7684c74c499900f4fc3c460ce.jpg"
           },
           {
             "Id": 35,
             "Name": "Master of the Magic Ritual",
             "Description": "Reach max level of the Ritual of Magic Absorption.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/048ca904a7b85874c4297074533ef0b6f8afa45d.jpg"
           },
           {
             "Id": 36,
             "Name": "Soul Eater",
             "Description": "Acquire 30,000 soul essences.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/8be09cc6d6e6991ec51f0258e63cfd6d90ffda86.jpg"
           },
           {
             "Id": 37,
             "Name": "Laid to Rest",
             "Description": "Defeat 1,000 enemies.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/0882d401f21c739e766c5851f61f5269bbd2aaae.jpg"
           },
           {
             "Id": 38,
             "Name": "Getting Close to The Truth",
             "Description": "Collect 30 items.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/3c547a8785298ea8338150feacb83b86142e04ab.jpg"
           },
           {
             "Id": 39,
             "Name": "Collector",
             "Description": "Collect 90 items.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/64cad115f8e79a3df270aada02a57214c1542e19.jpg"
           },
           {
             "Id": 40,
             "Name": "A Witch Revived",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/576da36619d4d63328e66fee2a174402d97945f7.jpg"
           },
           {
             "Id": 41,
             "Name": "Towering Tribulations",
             "Description": " Hidden.",
             "ImageUri": "https://cdn.cloudflare.steamstatic.com/steamcommunity/public/images/apps/1049890/7286be6fed34156e43dfb57af983e0c570bcc99e.jpg"
           }
         ]
         """;

    public AchievementMetadataProvider()
    {
        var achievementMetadatas = JsonSerializer.Deserialize<AchievementMetadata[]>(AchievementsMetadataJson)!;

        AchievementsMetadata = achievementMetadatas.ToDictionary(metadata => metadata.Id, metadata => metadata);
    }

    public record AchievementMetadata(int Id, string Name, string Description, string ImageUri);
}