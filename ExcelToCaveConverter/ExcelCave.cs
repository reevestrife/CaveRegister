namespace ExcelToCaveConverter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExcelCave
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExcelCaveId { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Tourist { get; set; }

        public string Pristine { get; set; }

        public string Certification { get; set; }

        public string ShortDescription { get; set; }

        public string Folder { get; set; }

        public string References { get; set; }

        public string TotalExt { get; set; }

        public string Horizontal { get; set; }

        public string Depth { get; set; }

        public string Survey { get; set; }

        public string Drop { get; set; }

        public string Climb { get; set; }

        public string Dig { get; set; }

        public string Squeeze { get; set; }

        public string Scuba { get; set; }

        public string AirFlow { get; set; }

        public string Potential { get; set; }

        public string Ladder { get; set; }

        public string Navigation { get; set; }

        public string Flooding { get; set; }

        public string Gated { get; set; }

        public string Unstable { get; set; }

        public string Squeeze2 { get; set; }

        public string Climbs { get; set; }

        public string BadAir { get; set; }

        public string Scuba2 { get; set; }

        public string Sump { get; set; }

        public string Srt { get; set; }

        public string Challanges { get; set; }

        public string Decorated { get; set; }

        public string LandOwnerName { get; set; }

        public string LandOwnerPhone { get; set; }

        public string LandOwnerEmail { get; set; }

        public string Permission { get; set; }

        public string SuperGroup { get; set; }

        public string Group { get; set; }

        public string Formation { get; set; }

        public string Member { get; set; }

        public string RockType { get; set; }

        public string Horseshoe { get; set; }

        public string Miniopterus { get; set; }

        public string FruitBat { get; set; }

        public string OtherBats { get; set; }

        public string Bats { get; set; }

        public string Snakes { get; set; }

        public string Leopard { get; set; }

        public string Antelope { get; set; }

        public string Porcupine { get; set; }

        public string Baboons { get; set; }

        public string Hyena { get; set; }

        public string Dassie { get; set; }

        public string Owl { get; set; }

        public string Birds { get; set; }

        public string Fish { get; set; }

        public string Civet { get; set; }

        public string Warthog { get; set; }

        public string Frogs { get; set; }

        public string Habitation { get; set; }

        public string CellarSpider { get; set; }

        public string CaveSpider { get; set; }

        public string Spiders { get; set; }

        public string Earwigs { get; set; }

        public string Cockroach { get; set; }

        public string Pseudoscorpion { get; set; }

        public string Pillbugs { get; set; }

        public string Shrimp { get; set; }

        public string TermiteTunnels { get; set; }

        public string Silverfish { get; set; }

        public string Centipede { get; set; }

        public string Beetle { get; set; }

        public string DungBeetle { get; set; }

        public string Muggies { get; set; }

        public string FlyingBugs { get; set; }

        public string Bees { get; set; }

        public string Crustacean { get; set; }

        public string Cricket { get; set; }

        public string CacoonsInWebs { get; set; }

        public string InsectPods { get; set; }

        public string Fleas { get; set; }

        public string AssassinBug { get; set; }

        public string Snail { get; set; }

        public string Worm { get; set; }

        public string Harvestman { get; set; }

        public string BugLife { get; set; }

        public string Guano { get; set; }

        public string Calcite { get; set; }

        public string Copper { get; set; }

        public string Mining { get; set; }

        public string PerchedWater { get; set; }

        public string WaterTable { get; set; }

        public string Stream { get; set; }

        public string IntermittentStream { get; set; }

        public string Water { get; set; }

        public string FossilHominin { get; set; }

        public string FossilBaboon { get; set; }

        public string FossilOtherPrimate { get; set; }

        public string FossilPrimate { get; set; }

        public string FossilCanid { get; set; }

        public string FossilHyena { get; set; }

        public string FossilFelid { get; set; }

        public string FossilCarnivore { get; set; }

        public string FossilSuid { get; set; }

        public string FossilEquid { get; set; }

        public string FossilBovid { get; set; }

        public string FossilMicroFauna { get; set; }

        public string Fossils { get; set; }

        public string Pottery { get; set; }

        public string RockPainting { get; set; }

        public string Structures { get; set; }

        public string MiningEquipment { get; set; }

        public string Tools { get; set; }

        public string Archealogical { get; set; }

        public string ModernBones { get; set; }

        public string Location { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string E1Elevation { get; set; }

        public string E1Lat { get; set; }

        public string E1Long { get; set; }

        public string E2Elevation { get; set; }

        public string E2Lat { get; set; }

        public string E2Long { get; set; }

        public string E3Elevation { get; set; }

        public string E3Lat { get; set; }

        public string E3Long { get; set; }

        public string E4Elevation { get; set; }

        public string E4Lat { get; set; }

        public string E4Long { get; set; }

        public string E5Elevation { get; set; }

        public string E5Lat { get; set; }

        public string E5Long { get; set; }

        public string Entrances { get; set; }

        public string Status { get; set; }
    }
}
