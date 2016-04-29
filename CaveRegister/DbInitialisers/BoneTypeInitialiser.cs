
using CaveRegister.Model;
using CaveRegister.Models;

namespace CaveRegister.DbInitialisers
{
	public static class BoneTypeInitialiser
	{
		public static void Ininitialise(ApplicationDbContext db)
		{
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Carpal, Name = BoneType.Carpal });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Tarsal, Name = BoneType.Tarsal });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Teeth, Name = BoneType.Teeth });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Canine, Name = BoneType.Canine });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Incisor, Name = BoneType.Incisor });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Molar, Name = BoneType.Molar });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Premolar, Name = BoneType.Premolar });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Metacarpal, Name = BoneType.Metacarpal });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Metatarsal, Name = BoneType.Metatarsal });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Cranium, Name = BoneType.Cranium });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Mandible, Name = BoneType.Mandible });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Maxilla, Name = BoneType.Maxilla });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Humerus, Name = BoneType.Humerus });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Ulna, Name = BoneType.Ulna });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Radius, Name = BoneType.Radius });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Vertibrae, Name = BoneType.Vertibrae });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Scapula, Name = BoneType.Scapula });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Pelvis, Name = BoneType.Pelvis });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Clavicle, Name = BoneType.Clavicle });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Phalanx, Name = BoneType.Phalanx });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Tibia, Name = BoneType.Tibia });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Fibula, Name = BoneType.Fibula });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Femur, Name = BoneType.Femur });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Sacrum, Name = BoneType.Sacrum });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Rib, Name = BoneType.Rib });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Talus, Name = BoneType.Talus });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Astragulus, Name = BoneType.Astragulus });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Calcaneus, Name = BoneType.Calcaneus });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Sternum, Name = BoneType.Sternum });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Horns, Name = BoneType.Horns });
			db.BoneTypes.Add(new BoneType() { BoneTypeId = BoneType.Patella, Name = BoneType.Patella });
		}
	}
}