using System.Text.Json;

namespace Vanessave.Services;

public class ValuablesMetadataProvider
{
    public Dictionary<int, ValuableData> ValuablesMetadata { get; }

    private const string ValuablesMetadataJson =
        """
        {
          "1": {
            "Id": 1,
            "Name": "Crafted Soul Reader",
            "Description": "A tool used by the Church which extracts any information remaining within the crafted soul to determine its power level. It is no surprise such an item would appear in a castle used as a facility for crafted soul study.",
            "ImageUri": "Sprite/Valuable001",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_01"
          },
          "2": {
            "Id": 2,
            "Name": "Stained Ribbon",
            "Description": "A delicate ribbon only affordable to members of the wealthy aristocracy. The dark spots are almost certainly dried blood, but an unscrupulous merchant could easily try to pass them off as mold stains.",
            "ImageUri": "Sprite/Valuable002",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_02"
          },
          "3": {
            "Id": 3,
            "Name": "Copper Coin",
            "Description": "A copper coin imprinted with a legendary hero\u0027s face. Any explorer would be fortunate to stumble upon such a find, but having to wade through a castle full of monsters to get it isn\u0027t quite so lucky...",
            "ImageUri": "Sprite/Valuable003",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_03"
          },
          "4": {
            "Id": 4,
            "Name": "Unknown House Banner",
            "Description": "There used to be time when these noble banners, commonly bestowed to heroes by the Church, could be found all over the continent.",
            "ImageUri": "Sprite/Valuable004",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_04"
          },
          "5": {
            "Id": 5,
            "Name": "Melted Silver Candlestick",
            "Description": "An elegant candlestick used by nobility. While the silver it\u0027s made of is strong enough to withstand any normal flame, the same can\u0027t be said of witch\u0027s fire...",
            "ImageUri": "Sprite/Valuable005",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_05"
          },
          "6": {
            "Id": 6,
            "Name": "Broken Cross Spear",
            "Description": "A weapon used by Church troops. The tip of the spear is the same shape as the Church\u0027s emblem, which serves to teach a valuable lesson to anyone who would consider betraying the Church.",
            "ImageUri": "Sprite/Valuable006",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_06"
          },
          "7": {
            "Id": 7,
            "Name": "Deformed Cavalier Armor",
            "Description": "Armor belonging to a high cavalier, made from a rare metal that\u0027s both light and strong. Judging by the damage it\u0027s suffered, the owner likely fell to something greater than a mere human.",
            "ImageUri": "Sprite/Valuable007",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_07"
          },
          "8": {
            "Id": 8,
            "Name": "Hero\u0027s Cross Sword",
            "Description": "A massive, heavy sword. Only a true hero gifted with crafted soul fragments would have the strength to wield it. Such a hero would be blessed with a truly magnificent power.",
            "ImageUri": "Sprite/Valuable008",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_08"
          },
          "9": {
            "Id": 9,
            "Name": "Giant Axe",
            "Description": "A weapon 3 full meters long, it\u0027s beyond the skill of any normal human to wield. Perhaps it was designed for use by the Church\u0027s doll units.",
            "ImageUri": "Sprite/Valuable009",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_09"
          },
          "10": {
            "Id": 10,
            "Name": "Shield of the Church",
            "Description": "Emblazoned with a large emblem of the Church, it has seen bloodshed on an impossible scale in battles against those who oppose the Church. Its duty came to an end when its wielder fell and the Knight Kingdom perished.",
            "ImageUri": "Sprite/Valuable010",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_10"
          },
          "11": {
            "Id": 11,
            "Name": "Broken Queen Doll",
            "Description": "All that remains of the doll unit\u0027s Queen Doll. As the head of the unit, its duty was to receive orders and pass them along. With the queen herself lost, the doll\u0027s fate was sealed.",
            "ImageUri": "Sprite/Valuable011",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_11"
          },
          "12": {
            "Id": 12,
            "Name": "Pointy Witch\u0027s Hat",
            "Description": "A covering worn by the Church Witch. Any skilled witch is an oppressive force on the battlefield, so she neither seeks nor needs protection in combat.",
            "ImageUri": "Sprite/Valuable012",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_12"
          },
          "13": {
            "Id": 13,
            "Name": "Sleeve Dagger",
            "Description": "A small dagger that can be hidden up a sleeve or other areas of the body. Many nobles required their servants to carry such weapons.",
            "ImageUri": "Sprite/Valuable013",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_13"
          },
          "14": {
            "Id": 14,
            "Name": "Corpse Shroud",
            "Description": "This once belonged to a refugee oppressed by the Church. Those who died attempting to flee the Church were considered lucky; if you were captured by them, you would suffer eternal pain whether dead or alive.",
            "ImageUri": "Sprite/Valuable014",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_14"
          },
          "15": {
            "Id": 15,
            "Name": "Headcutter Circular Saw",
            "Description": "Mostly used to dissect experiment subjects in the pursuit of doll transformation. Church researchers have long debated whether the soul dwelled in the heart or brain, but they seem to have finally reached a consensus.",
            "ImageUri": "Sprite/Valuable015",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_15"
          },
          "16": {
            "Id": 16,
            "Name": "Test Subject Manacle",
            "Description": "A restraint used to bind a subject. It is covered in blood and rust, clear signs of inhumane treatment. Of course, they themselves would soon become inhuman creatures, so the question of morality is an open-ended one.",
            "ImageUri": "Sprite/Valuable016",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_16"
          },
          "17": {
            "Id": 17,
            "Name": "Tattered Maid Outfit",
            "Description": "A set of clothing apparently belonging to the servant of a noble house. It is specially designed to grant its wearer surprising agility, allowing them a fighting chance against assassins and other intruders.",
            "ImageUri": "Sprite/Valuable017",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_17"
          },
          "18": {
            "Id": 18,
            "Name": "Soul Doll Remnant",
            "Description": "A byproduct of the production of a Soul Doll. While their creation remains a mystery, their ability to earn victory in battle is invaluable. They\u0027re also used to guide heretics back to the path of \u0022normalcy.\u0022",
            "ImageUri": "Sprite/Valuable018",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_18"
          },
          "19": {
            "Id": 19,
            "Name": "Knight\u0027s Halberd",
            "Description": "A weapon commonly used by a doll unit knight. Each unit consists of a king, or commander, designated by the Church, a queen which excels in raw power, a pair of bishops, knights, and rooks, and eight pawns.",
            "ImageUri": "Sprite/Valuable019",
            "AudioUri": "ItemVoice/Tania_Noeff_Dougu_19"
          },
          "20": {
            "Id": 20,
            "Name": "Weathered Cloak",
            "Description": "A roughly made cloak. Judging by the material, it was likely handcrafted by a member of the bestian tribe. Its quality is nowhere near that of what a human could produce.",
            "ImageUri": "Sprite/Valuable020",
            "AudioUri": "ItemVoice/Monica_Dougu_01"
          },
          "21": {
            "Id": 21,
            "Name": "Silver Coin",
            "Description": "A token imprinted with the image of the Saint. It is used mostly by upper-class humans for trading goods. Using the image of a divine figure to purchase slaves off the black market... What could be more bitterly appropriate?",
            "ImageUri": "Sprite/Valuable021",
            "AudioUri": "ItemVoice/Monica_Dougu_02"
          },
          "22": {
            "Id": 22,
            "Name": "Intricate Clock",
            "Description": "An expensive timepiece crafted by a talented human watchmaker. For the barbaric bestians who measure time by observing the sky, this item was useless. The tribe leader kept it in his home simply as a symbol of his own majesty.",
            "ImageUri": "Sprite/Valuable022",
            "AudioUri": "ItemVoice/Monica_Dougu_03"
          },
          "23": {
            "Id": 23,
            "Name": "Cursed Turquoise Necklace",
            "Description": "A necklace adorned with turquoise. It\u0027s said that each of its previous owners met an unimaginably tragic fate.",
            "ImageUri": "Sprite/Valuable023",
            "AudioUri": "ItemVoice/Monica_Dougu_04"
          },
          "24": {
            "Id": 24,
            "Name": "Glass Lantern",
            "Description": "A premium item that lights up the darkness. Only humans are capable of making glass, so objects like this can fetch many a beast hide among local border tribes.",
            "ImageUri": "Sprite/Valuable024",
            "AudioUri": "ItemVoice/Monica_Dougu_05"
          },
          "25": {
            "Id": 25,
            "Name": "Copper Ingot",
            "Description": "Lumps of copper used by certain bestian tribes as a currency for trading. The uncivilized barbarians finally embraced the concept of money after years of trading with humans.",
            "ImageUri": "Sprite/Valuable025",
            "AudioUri": "ItemVoice/Monica_Dougu_06"
          },
          "26": {
            "Id": 26,
            "Name": "Teddy Bear",
            "Description": "Some human merchants like to purchase hides from the bestians, imbue them with a bit of human magic, then sell them back to the bestians for several times the original price. Truly, that is the heart and spirit of commerce.",
            "ImageUri": "Sprite/Valuable026",
            "AudioUri": "ItemVoice/Monica_Dougu_07a"
          },
          "27": {
            "Id": 27,
            "Name": "Fractured Stone Axe",
            "Description": "A stone axe favored by bestians. The surface is covered in scratches from superior sharpened weapons. How foolish must they be to think they could challenge a human?",
            "ImageUri": "Sprite/Valuable027",
            "AudioUri": "ItemVoice/Monica_Dougu_08"
          },
          "28": {
            "Id": 28,
            "Name": "Cage",
            "Description": "An enclosure for keeping livestock... or perhaps children?",
            "ImageUri": "Sprite/Valuable028",
            "AudioUri": "ItemVoice/Monica_Dougu_09"
          },
          "29": {
            "Id": 29,
            "Name": "Slave Branding Iron",
            "Description": "A tool used to leave a permanent mark on a slave. That way, though the slave may try and run, they can never truly escape their cruel destiny.",
            "ImageUri": "Sprite/Valuable029",
            "AudioUri": "ItemVoice/Monica_Dougu_10"
          },
          "30": {
            "Id": 30,
            "Name": "Merchant\u0027s Ledger",
            "Description": "Looking over the entries, it is clear that a human and bestian developed an extensive trading relationship as time went on. Some tribes are crossed out, with a note that reads, \u0022All value extracted.\u0022",
            "ImageUri": "Sprite/Valuable030",
            "AudioUri": "ItemVoice/Monica_Dougu_11"
          },
          "31": {
            "Id": 31,
            "Name": "Slave Tag",
            "Description": "These tags are brutally inserted into bestian slaves\u0027 body, and the slaves\u0027 physical condition is written on the tag for the buyer\u0027s convenience.",
            "ImageUri": "Sprite/Valuable031",
            "AudioUri": "ItemVoice/Monica_Dougu_12"
          },
          "32": {
            "Id": 32,
            "Name": "Slave Collar",
            "Description": "Long ago, humans were often hunted by other races. Back then, it wasn\u0027t uncommon to see a human wearing one of these. Now, after a century under the Church\u0027s leadership, the only ones sporting a collar like this are demi-humans.",
            "ImageUri": "Sprite/Valuable032",
            "AudioUri": "ItemVoice/Monica_Dougu_13"
          },
          "33": {
            "Id": 33,
            "Name": "Bestian Palm",
            "Description": "Bestian is a collective term referring to any race with animalistic body parts. They have diverse religious beliefs, and were longstanding trade partners with humans before the Church branded them heretics.",
            "ImageUri": "Sprite/Valuable033",
            "AudioUri": "ItemVoice/Monica_Dougu_14"
          },
          "34": {
            "Id": 34,
            "Name": "Bestian Ear",
            "Description": "Bestian is a collective term referring to any race with animalistic body parts. Once the Church ordered their eradication, these animalistic ears became a highly prized collector\u0027s item.",
            "ImageUri": "Sprite/Valuable034",
            "AudioUri": "ItemVoice/Monica_Dougu_15"
          },
          "35": {
            "Id": 35,
            "Name": "Dwarven Metalwork",
            "Description": "Dwarves are master craftsmen famous for their work with metal, and their decorative style. They became endangered due to long-term harassment from their onetime neighbors, the blood orcs.",
            "ImageUri": "Sprite/Valuable035",
            "AudioUri": "ItemVoice/Monica_Dougu_16"
          },
          "36": {
            "Id": 36,
            "Name": "High Elf\u0027s Mana Ring",
            "Description": "High elves were talented in magic, and developed their own culture and civilization. But once humanity conquered their capital city, they were never seen or heard from again.",
            "ImageUri": "Sprite/Valuable036",
            "AudioUri": "ItemVoice/Monica_Dougu_17"
          },
          "37": {
            "Id": 37,
            "Name": "Forest Elf\u0027s Vest",
            "Description": "A very warm and flexible vest weaved using special grass fibers. The center of the chest bears a large slit, likely the result of a human sword.",
            "ImageUri": "Sprite/Valuable037",
            "AudioUri": "ItemVoice/Monica_Dougu_18"
          },
          "38": {
            "Id": 38,
            "Name": "Dark Elf\u0027s Ear Sample",
            "Description": "Dark elves are considered fairly \u0022social\u0022 compared to their other elf relatives, in that they\u0027re willing to ally themselves with whoever they think can benefit them the most. A pity they chose not to side with the humans...",
            "ImageUri": "Sprite/Valuable038",
            "AudioUri": "ItemVoice/Monica_Dougu_19"
          },
          "39": {
            "Id": 39,
            "Name": "Dark Elf\u0027s Short Bow",
            "Description": "Elves are master of archery and would normally prefer to use a longbow. For dark elves who spend a lot time with demi-human thieves, a short bow is much more versatile in combat, and easier to carry over long distances.",
            "ImageUri": "Sprite/Valuable039",
            "AudioUri": "ItemVoice/Monica_Dougu_20"
          },
          "40": {
            "Id": 40,
            "Name": "Ogre\u0027s Kidney",
            "Description": "A rare sample possessed by a body harvester. While they used to be seen all over the continent, the ogres have now gone extinct. Whoever or whatever opposes the Church will pay the price in the end.",
            "ImageUri": "Sprite/Valuable040",
            "AudioUri": "ItemVoice/Monica_Dougu_21"
          },
          "41": {
            "Id": 41,
            "Name": "Ogre\u0027s Eye",
            "Description": "A gigantic eye the size of a human child\u0027s skull. The Church discovered that despite their enormous size, the amount of soul essence residing in an ogre\u0027s body is no different from an average human.",
            "ImageUri": "Sprite/Valuable041",
            "AudioUri": "ItemVoice/Monica_Dougu_22"
          },
          "42": {
            "Id": 42,
            "Name": "Ogre\u0027s Club",
            "Description": "The two-headed ogre is a ferocious creature, prone to conflict. They wandered these lands freely before becoming a target of the church. They often traveled alone, occasionally joining up with demi-human thief brotherhoods.",
            "ImageUri": "Sprite/Valuable042",
            "AudioUri": "ItemVoice/Monica_Dougu_23"
          },
          "43": {
            "Id": 43,
            "Name": "Bloodstained Javelin",
            "Description": "Before the Church gained power, humans were seen as easy prey for demi-human raiders. These days, the tables have turned and groups of human knights have their way with their demi-human enemies.",
            "ImageUri": "Sprite/Valuable043",
            "AudioUri": "ItemVoice/Monica_Dougu_24"
          },
          "44": {
            "Id": 44,
            "Name": "Nomad\u0027s Cookware",
            "Description": "A nomad\u0027s pot that makes for a perfect cooking implement when placed on a heated stone slab. A proper meal was all the average nomad could hope for, though their wish was rarely granted.",
            "ImageUri": "Sprite/Valuable044",
            "AudioUri": "ItemVoice/Vanessa_Dougu_01"
          },
          "45": {
            "Id": 45,
            "Name": "Golden Coin",
            "Description": "There is no visible image on the coin, because it depicts the god of another dimension which is unreachable and unseeable by mere mortals.",
            "ImageUri": "Sprite/Valuable045",
            "AudioUri": "ItemVoice/Vanessa_Dougu_02"
          },
          "46": {
            "Id": 46,
            "Name": "Tooth Thief\u0027s Pouch",
            "Description": "Places ransacked by demi-humans leave behind only corpses. The teeth of the dead are often pillaged by merchants with little compassion for their own kind, as a tidy profit can be made selling teeth on the black market.",
            "ImageUri": "Sprite/Valuable046",
            "AudioUri": "ItemVoice/Vanessa_Dougu_03"
          },
          "47": {
            "Id": 47,
            "Name": "Blood Orc\u0027s Skin Sample",
            "Description": "A rare piece obtained by a body collector. Despite their iron-hard skin, a blood orc is no match for a hero in a one-on-one scenario.",
            "ImageUri": "Sprite/Valuable047",
            "AudioUri": "ItemVoice/Vanessa_Dougu_04"
          },
          "48": {
            "Id": 48,
            "Name": "Chief\u0027s Skull",
            "Description": "Conquered by the humans, the blood orc chief\u0027s skull became a chalice for which the human leader celebrated their victory. For the victor of a battle, there is nothing sweeter than a triumphant banquet.",
            "ImageUri": "Sprite/Valuable048",
            "AudioUri": "ItemVoice/Vanessa_Dougu_05"
          },
          "49": {
            "Id": 49,
            "Name": "Miner\u0027s Pickaxe",
            "Description": "Vagrants explored ancient ruins in search of valuable materials to turn into simple coins. They unexpectedly uncovered the lost technology of crafted souls, which they attributed to God\u0027s will.",
            "ImageUri": "Sprite/Valuable049",
            "AudioUri": "ItemVoice/Vanessa_Dougu_06"
          },
          "50": {
            "Id": 50,
            "Name": "Crafted Soul Injector",
            "Description": "A tool used by priests to inject shards of a crafted soul into living beings. It\u0027s said to be an extremely brutal process but deemed a necessary sacrifice to obtain such incredible power.",
            "ImageUri": "Sprite/Valuable050",
            "AudioUri": "ItemVoice/Vanessa_Dougu_07"
          },
          "51": {
            "Id": 51,
            "Name": "Hero\u0027s Insignia",
            "Description": "Only the most resilient soul can withstand the power of a crafted soul, so only those gifted with extraordinary willpower were able to become heroes.",
            "ImageUri": "Sprite/Valuable051",
            "AudioUri": "ItemVoice/Vanessa_Dougu_08"
          },
          "52": {
            "Id": 52,
            "Name": "Mutated Beast Claw",
            "Description": "Those who failed to accept the power of a crafted soul turned into creatures of demonic appearance. When this happened, the Church granted them mercy and ended their suffering.",
            "ImageUri": "Sprite/Valuable052",
            "AudioUri": "ItemVoice/Vanessa_Dougu_09"
          },
          "53": {
            "Id": 53,
            "Name": "Ceremonial Sword",
            "Description": "A divine sword blessed by the Church. This glorious symbol was given to veteran heroes to commend their dedication and loyalty.",
            "ImageUri": "Sprite/Valuable053",
            "AudioUri": "ItemVoice/Vanessa_Dougu_10"
          },
          "54": {
            "Id": 54,
            "Name": "Banner of the Lance Hero",
            "Description": "The banner of a great Church hero who fought in the First Crusade of the Apocalypse Age, year 100. She led the Apocalypse Knights that defeated the blood orcs, bringing humanity into global power.",
            "ImageUri": "Sprite/Valuable054",
            "AudioUri": "ItemVoice/Vanessa_Dougu_11"
          },
          "55": {
            "Id": 55,
            "Name": "Banner of the Lionhearted",
            "Description": "The banner of a great Church hero who fought in the First Crusade in the Apocalypse Age, year 100. After defeating countless blood orcs, he was rewarded with lands and title, and given doll units to protect the new border.",
            "ImageUri": "Sprite/Valuable055",
            "AudioUri": "ItemVoice/Vanessa_Dougu_12"
          },
          "56": {
            "Id": 56,
            "Name": "Knight Kingdom Crown",
            "Description": "To manage the vast lands won in their various wars, the Church appointed different heroes to rule these new kingdoms and defend the borders from invading enemies.",
            "ImageUri": "Sprite/Valuable056",
            "AudioUri": "ItemVoice/Vanessa_Dougu_13"
          },
          "57": {
            "Id": 57,
            "Name": "Lady\u0027s Feather Hat",
            "Description": "A flamboyant hat worn by ladies of the Knight Kingdom when attending lavish events. Their luxurious lifestyle makes neighboring nations quite jealous.",
            "ImageUri": "Sprite/Valuable057",
            "AudioUri": "ItemVoice/Vanessa_Dougu_14"
          },
          "58": {
            "Id": 58,
            "Name": "Super Cleanser Soap",
            "Description": "A common consumable in the Knight Kingdom. The soap is made with bestian body oil and is extremely effective at removing any stain. Finally, those filthy bestians have proven to be of some use.",
            "ImageUri": "Sprite/Valuable058",
            "AudioUri": "ItemVoice/Vanessa_Dougu_15"
          },
          "59": {
            "Id": 59,
            "Name": "Exquisite Leather Lamp",
            "Description": "A common piece of furniture in the Knight Kingdom, this lamp does not extinguish easily. Its bestian skin-covered exterior is more durable and fine looking than ones made from common animal materials.",
            "ImageUri": "Sprite/Valuable059",
            "AudioUri": "ItemVoice/Vanessa_Dougu_16"
          },
          "60": {
            "Id": 60,
            "Name": "Premium Grass Ash",
            "Description": "A fertilizer made in the Knight Kingdom. It greatly accelerates the growth of any crop it\u0027s used on. While merchants advertise it as an ash derived from grass, rumor has it that it\u0027s actually comprised of burnt bestian corpses.",
            "ImageUri": "Sprite/Valuable060",
            "AudioUri": "ItemVoice/Vanessa_Dougu_17"
          },
          "61": {
            "Id": 61,
            "Name": "Knight Kingdom Entry Pass",
            "Description": "The Knight Kingdom is a dream land for humanity. Many would give all they have to become a citizen of the realm.",
            "ImageUri": "Sprite/Valuable061",
            "AudioUri": "ItemVoice/Vanessa_Dougu_18"
          },
          "62": {
            "Id": 62,
            "Name": "Bone Chess Set",
            "Description": "A popular board game in the Knight Kingdom. Each piece resembles a different bestian. The rules are similar to regular chess, but a player must defeat every piece to win. Some sets are made from real bestian bones.",
            "ImageUri": "Sprite/Valuable062",
            "AudioUri": "ItemVoice/Vanessa_Dougu_19"
          },
          "63": {
            "Id": 63,
            "Name": "Inquisitor\u0027s List",
            "Description": "Inquisitors eliminate any potential threat to the Church, and any name written on such a list is sure to face the judgment of God.",
            "ImageUri": "Sprite/Valuable063",
            "AudioUri": "ItemVoice/Vanessa_Dougu_20"
          },
          "64": {
            "Id": 64,
            "Name": "Envoy\u0027s Rune",
            "Description": "A silver rune used by the Knight Kingdom. It\u0027s said that the kingdom often sends envoys carrying such runes to the Church to deliver secret messages.",
            "ImageUri": "Sprite/Valuable064",
            "AudioUri": "ItemVoice/Vanessa_Dougu_21"
          },
          "65": {
            "Id": 65,
            "Name": "Declaration of War",
            "Description": "The Knight Kingdom was accused of secretly hiding bestians and heretics, so the other kingdoms decided to unite and bring down this \u0022sinful\u0022 nation. Those who truly know the Knight King find such pretenses ludicrous.",
            "ImageUri": "Sprite/Valuable065",
            "AudioUri": "ItemVoice/Vanessa_Dougu_22"
          },
          "66": {
            "Id": 66,
            "Name": "Attic Key",
            "Description": "Outside of the Knight Kingdom, bestian slavery is uncommon. Aristocrats tend to hide their slaves in attics within their walls for their private use. In this castle, however, the only slaves are ones subject to experimentation.",
            "ImageUri": "Sprite/Valuable066",
            "AudioUri": "ItemVoice/Vanessa_Dougu_23"
          },
          "67": {
            "Id": 67,
            "Name": "Halfling\u0027s Forelimb",
            "Description": "Adult halflings are roughly as tall as a human child, never wear shoes, and are experts in infiltration and burglary. According to human law, burglars are to have their arms chopped off\u2014an unforgettable lesson for a thief.",
            "ImageUri": "Sprite/Valuable067",
            "AudioUri": "ItemVoice/Vanessa_Dougu_24"
          },
          "68": {
            "Id": 68,
            "Name": "Ratian Claw",
            "Description": "Ratians are essentially masculine groundhogs in humanoid form. They dig through the ground and ambush their enemies. Their claws have evolved to dig through dirt easily, and they are said to bring good luck.",
            "ImageUri": "Sprite/Valuable068",
            "AudioUri": "ItemVoice/Vanessa_Dougu_25"
          },
          "69": {
            "Id": 69,
            "Name": "Pontiff\u0027s Scepter",
            "Description": "In the Apocalypse Age year 160, the Saint took over leadership of the Church. The pontiff\u0027s flamboyant scepter was left collecting dust.",
            "ImageUri": "Sprite/Valuable069",
            "AudioUri": "ItemVoice/Vanessa_Dougu_26"
          },
          "70": {
            "Id": 70,
            "Name": "Abandoned Rag Doll",
            "Description": "The human race suffered during the early days of human history, just like this doll. A girl who lost her family vowed to defend of humanity and slay the demi-humans. Not long after the rise of the Church, her wish was granted.",
            "ImageUri": "Sprite/Valuable070",
            "AudioUri": "ItemVoice/Vanessa_Dougu_27"
          },
          "71": {
            "Id": 71,
            "Name": "Apocalypse Knight Record",
            "Description": "As the first knightly order of the Church, the Apocalypse Knights contributed greatly to the civil war, emerging from it battered and depleted. Eventually, a new commander arose to give it a complete overhaul.",
            "ImageUri": "Sprite/Valuable071",
            "AudioUri": "ItemVoice/Vanessa_Dougu_28"
          },
          "72": {
            "Id": 72,
            "Name": "Apocalypse Knight Shield",
            "Description": "A shield used among defensive units within the Apocalypse Knights. Their shield walls were famous for being completely impenetrable.",
            "ImageUri": "Sprite/Valuable072",
            "AudioUri": "ItemVoice/Vanessa_Dougu_29"
          },
          "73": {
            "Id": 73,
            "Name": "Apocalypse Knight Axe",
            "Description": "An axe favored by Apocalypse Knights. No heretic can stand against the judgment of such a terrible weapon.",
            "ImageUri": "Sprite/Valuable073",
            "AudioUri": "ItemVoice/Vanessa_Dougu_30"
          },
          "74": {
            "Id": 74,
            "Name": "Apocalypse Knight Staff",
            "Description": "The weapon of the Apocalypse Knight mage. It enhances magical power while supporting the frontline by raining down catastrophe upon the enemy.",
            "ImageUri": "Sprite/Valuable074",
            "AudioUri": "ItemVoice/Vanessa_Dougu_31"
          },
          "75": {
            "Id": 75,
            "Name": "Apocalypse Knight Bow",
            "Description": "The weapon of the Apocalypse Knight archer. It\u0027s a surprisingly frightful weapon, allowing for deadly precision even over long distances.",
            "ImageUri": "Sprite/Valuable075",
            "AudioUri": "ItemVoice/Vanessa_Dougu_32"
          },
          "76": {
            "Id": 76,
            "Name": "Apocalypse Knight Sword",
            "Description": "A great sword used by many Apocalypse Knights. Many heretics have fallen to its ruthless blows.",
            "ImageUri": "Sprite/Valuable076",
            "AudioUri": "ItemVoice/Vanessa_Dougu_33"
          },
          "77": {
            "Id": 77,
            "Name": "The Throne",
            "Description": "A doorway to a hidden dimension, and both the origin and final destination of all crafted souls. The Church is not responsible for its creation; its existence is due to a powerful being invisible to all mere mortals.",
            "ImageUri": "Sprite/Valuable077",
            "AudioUri": "ItemVoice/Vanessa_Dougu_34"
          },
          "78": {
            "Id": 78,
            "Name": "Ancient Throne Rune",
            "Description": "An ancient rune that has been decrypted by linguists to mean \u0022doorway.\u0022 Its connection to the Throne is still not understood, although many scholars have posited many a theory.",
            "ImageUri": "Sprite/Valuable078",
            "AudioUri": "ItemVoice/Vanessa_Dougu_35"
          },
          "79": {
            "Id": 79,
            "Name": "Doctor\u0027s Mask",
            "Description": "The Church convinced people that the Beast Witch spread a plague to harm humanity. They claimed that those who succumbed to the plague became the witch\u0027s slaves after death in order to coax them into receiving their \u0022treatment.\u0022",
            "ImageUri": "Sprite/Valuable079",
            "AudioUri": "ItemVoice/ga_it_cat_001"
          },
          "80": {
            "Id": 80,
            "Name": "Ceremonial Incense",
            "Description": "Incense used by the heretics while worshipping their false god. There are rumors that the incense has a cleansing effect on the plague. That would explain how such inferior beings could be immune...",
            "ImageUri": "Sprite/Valuable080",
            "AudioUri": "ItemVoice/ga_it_cat_002"
          },
          "81": {
            "Id": 81,
            "Name": "Moonlight Blade",
            "Description": "The magical weapon of a Beast Witch follower, which can absorb energy from moonlight. As far as humans are concerned, they\u0027re nothing more than self-righteous vandals, threatening the safety and prosperity of the caravans.",
            "ImageUri": "Sprite/Valuable081",
            "AudioUri": "ItemVoice/ga_it_cat_003"
          },
          "82": {
            "Id": 82,
            "Name": "Prostitute\u0027s Chiffon",
            "Description": "A special garment for work utilizing its wearer\u0027s physical vessel. Its revealing nature is designed to provoke a primitive desire out of would-be clients. The fee is great, but at least clients get to keep this as a souvenir.",
            "ImageUri": "Sprite/Valuable082",
            "AudioUri": "ItemVoice/ga_it_cat_004"
          },
          "83": {
            "Id": 83,
            "Name": "Castle Blueprint",
            "Description": "A piece of a merchant\u0027s collection displaying the layout of a castle built centuries ago. The blueprint doesn\u0027t match the actual layout exactly... perhaps there are some secret rooms that would explain the discrepancy.",
            "ImageUri": "Sprite/Valuable083",
            "AudioUri": "ItemVoice/ga_it_cat_005"
          },
          "84": {
            "Id": 84,
            "Name": "Witch Worshipper Puppet",
            "Description": "An idol created by a heretic to honor the Beast Witch. The antlers are a symbol of impurity. The Saint once personally delved into the depths of the forest occupied by the heretical group in order to eliminate their presence.",
            "ImageUri": "Sprite/Valuable084",
            "AudioUri": "ItemVoice/ga_it_cat_006"
          },
          "85": {
            "Id": 85,
            "Name": "Polymorphism Scroll",
            "Description": "A scroll confiscated from the heretics that depicts bestians with the special ability to transform between beast and human forms. Such a ridiculous thing could only take place in a heretic\u0027s fantasy.",
            "ImageUri": "Sprite/Valuable085",
            "AudioUri": "ItemVoice/ga_it_cat_007"
          },
          "86": {
            "Id": 86,
            "Name": "Missing Person Poster",
            "Description": "A significant number of humans went missing during the plague, especially in cities where the Church has a strong influence. It would appear God showed no mercy to these poor souls.",
            "ImageUri": "Sprite/Valuable086",
            "AudioUri": "ItemVoice/ga_it_cat_008"
          },
          "87": {
            "Id": 87,
            "Name": "Saint\u0027s Cane",
            "Description": "An ordinary looking shepherd\u0027s cane that emits the power of a blessing. True power casts down those who stand against it without decoration or fanfare.",
            "ImageUri": "Sprite/Valuable087",
            "AudioUri": "ItemVoice/ga_it_cat_009"
          },
          "88": {
            "Id": 88,
            "Name": "Hero Summon Rune",
            "Description": "A rune used by the Church to summon heroes across the continent. Once the Saint cast down the Beast Witch, it lost most of its utility. These days, even common thieves have no trouble ransacking bestian tribes.",
            "ImageUri": "Sprite/Valuable088",
            "AudioUri": "ItemVoice/ga_it_cat_010"
          },
          "89": {
            "Id": 89,
            "Name": "Bloodstained Key",
            "Description": "The Church established structures, such as castles, to protect human settlements from invaders. The Beast Witch uses her servants to raid these castles in the night. Though well-guarded, the servants always find a way in...",
            "ImageUri": "Sprite/Valuable089",
            "AudioUri": "ItemVoice/ga_it_cat_011"
          },
          "90": {
            "Id": 90,
            "Name": "Enchanted Shackles",
            "Description": "Despite its poor state, its residual power is still strong. The restraint was used to restrict the flow of magic from whomever it bound, as if the captor were afraid their prisoner might transform into some kind of monstrosity.",
            "ImageUri": "Sprite/Valuable090",
            "AudioUri": "ItemVoice/ga_it_cat_012"
          },
          "91": {
            "Id": 91,
            "Name": "Gaseous Soul Essence",
            "Description": "A soul without form, clinging to the world of the living, will eventually perish. All souls are made from soul essence. It is the origin of all living things, and can be found in the soul of every being.",
            "ImageUri": "Sprite/Valuable091",
            "AudioUri": "ItemVoice/ga_di_cat_001"
          },
          "92": {
            "Id": 92,
            "Name": "Semi-gaseous Soul Essence",
            "Description": "A soul without form will perish, leaving behind only its essence. They say witches naturally resonate with soul essence, and this is what allows them to cast magic.",
            "ImageUri": "Sprite/Valuable092",
            "AudioUri": "ItemVoice/ga_di_cat_002"
          },
          "93": {
            "Id": 93,
            "Name": "Enchanted Soul Shard",
            "Description": "All forms are destined perish. Even the Church\u0027s creations cannot escape this fate. Crafted souls use ancient magic to extract soul essence and turn it into pure energy, but the vessel, unfortunately, dies in the process.",
            "ImageUri": "Sprite/Valuable093",
            "AudioUri": "ItemVoice/ga_di_cat_003"
          },
          "94": {
            "Id": 94,
            "Name": "Empowered Soul Shard",
            "Description": "The dolls created by the Church continue to emit the power of a crafted soul even after they are destroyed. Crafted souls infused with soul essence are equipped with the ability to learn and perform simple commands.",
            "ImageUri": "Sprite/Valuable094",
            "AudioUri": "ItemVoice/ga_di_cat_004"
          },
          "95": {
            "Id": 95,
            "Name": "Refined Soul Shard",
            "Description": "A remarkable creation by the Church, in which the souls of prisoners, slaves, and heretics alike rattle around together in a single body. Created with condensed soul essence, it provides great power to its owner.",
            "ImageUri": "Sprite/Valuable095",
            "AudioUri": "ItemVoice/ga_di_cat_005"
          },
          "96": {
            "Id": 96,
            "Name": "Knight\u0027s Soul Shard",
            "Description": "Many heroes\u0027 bodies eventually gave way to the burden of battle. The dolls were far more resilient, but it didn\u0027t take long for the Church to make the troubling discovery that refined soul essence could produce consciousness.",
            "ImageUri": "Sprite/Valuable096",
            "AudioUri": "ItemVoice/ga_di_nbt_001"
          },
          "97": {
            "Id": 97,
            "Name": "Faithful Soul Shard",
            "Description": "The faithful servant remained loyal even after meeting their tragic fate. A crafted soul is essentially soul essence combined from several souls. The most resilient soul within the bunch usually becomes the one in control.",
            "ImageUri": "Sprite/Valuable097",
            "AudioUri": "ItemVoice/ga_di_nin_001"
          },
          "98": {
            "Id": 98,
            "Name": "Lost Maiden\u0027s Soul Shard",
            "Description": "Losing her family was merely the beginning of the maiden\u0027s cruel fate... When the Church reached a bottleneck with doll technology, they found out that witches were highly compatible with crafted souls.",
            "ImageUri": "Sprite/Valuable098",
            "AudioUri": "ItemVoice/ga_di_nin_002"
          },
          "99": {
            "Id": 99,
            "Name": "Child\u0027s Soul Shard",
            "Description": "Betrayed by those of different blood, one child stayed while all the others left. This doll went berserk and killed many Church researchers, and was ultimately abandoned in the laboratory.",
            "ImageUri": "Sprite/Valuable099",
            "AudioUri": "ItemVoice/ga_di_nin_003"
          },
          "100": {
            "Id": 100,
            "Name": "King\u0027s Final Honor",
            "Description": "The heroes who served the Church were replaced by Soul Dolls. To give the heroes a new purpose, the Church had them build kingdoms on lands conquered by the Church.",
            "ImageUri": "Sprite/Valuable100",
            "AudioUri": "ItemVoice/ga_di_nin_004"
          },
          "101": {
            "Id": 101,
            "Name": "Proud King\u0027s Crafted Soul Shard",
            "Description": "Reminiscing on past glory, a king who once governed a sliver of heaven on earth refuses to rest.",
            "ImageUri": "Sprite/Valuable101",
            "AudioUri": "ItemVoice/ga_di_nbt_002"
          },
          "102": {
            "Id": 102,
            "Name": "Lost Maiden\u0027s Crafted Soul Shard",
            "Description": "A maiden stands confused before of the crossroad of fate. Once an enemy of the Church, a compliant personality was imparted into this craft soul, suppressing her will and turning her into the Church Witch.",
            "ImageUri": "Sprite/Valuable102",
            "AudioUri": "ItemVoice/ga_di_nbt_003"
          },
          "103": {
            "Id": 103,
            "Name": "Loyal Soul Shard",
            "Description": "The remainder of this soul clings stubbornly to its shell, driven by its undying loyalty.",
            "ImageUri": "Sprite/Valuable103",
            "AudioUri": "ItemVoice/ga_di_nin_005"
          }
        }
        """;

    public ValuablesMetadataProvider()
    {
        ValuablesMetadata = JsonSerializer.Deserialize<Dictionary<int, ValuableData>>(ValuablesMetadataJson)!;
    }

    public record ValuableData(int Id, string Name, string Description, string ImageUri, string AudioUri);
}