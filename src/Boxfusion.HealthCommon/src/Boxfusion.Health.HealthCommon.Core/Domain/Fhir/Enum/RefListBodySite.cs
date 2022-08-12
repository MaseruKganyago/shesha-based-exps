using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "BodySites")]
	public enum RefListBodySite: long
	{
        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior carpal region")]
        posteriorCarpalRegion = 106004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal part of placenta")]
        fetalPartOfPlacenta = 107008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Condylar emissary vein")]
        condylarEmissaryVein = 108003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Visceral layer of Bowman's capsule")]
        visceralLayerOfBowmansCapsule = 110001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parathyroid gland")]
        parathyroidGland = 111002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of medial surface of index finger")]
        subcutaneousTissueOfMedialSurfaceOfIndexFinger = 116007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coronoid process of mandible")]
        coronoidProcessOfMandible = 124002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Central pair of microtubules, cilium or flagellum, not bacterial")]
        centralPairOfMicrotubules = 149003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep circumflex artery of ilium")]
        deepCircumflexArteryOfIlium = 155008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supraclavicular part of brachial plexus")]
        supraclavicularPartOfBrachialPlexus = 167005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior division of renal artery")]
        anteriorDivisionOfRenalArtery = 202009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left commissure of aortic valve")]
        leftCommissureOfAorticValve = 205006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gluteus maximus muscle")]
        gluteusMaximusMuscle = 206007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular surface, phalanges, of fourth metacarpal bone")]
        AricularSurfacePhalangesOfFourthMetacarpalBone = 221001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Canal of Hering")]
        canalOfHering = 227002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hepatocolic ligament")]
        hepatocolicLigament = 233006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior labial artery")]
        superiorLabialArtery = 235004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral vestibular nucleus")]
        lateralVestibularNucleus = 246001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mesotympanum")]
        mesotympanum = 247005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pectoral region")]
        pectoralRegion = 251007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Kupffer cell")]
        kupfferCell = 256002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thoracic nerve")]
        thoracicNerve = 263002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right lower lobe of lung")]
        rightLowerlobeOflung = 266005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior articular process of lumbar vertebra")]
        superiorArticularProcessOfLumbarVertebra = 272005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral myocardium")]
        lateralMyocardium = 273000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Central axillary lymph node")]
        centralAxillaryLymphNode = 283001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Flexor tendon and tendon sheath of fourth toe")]
        flexorTendonAndTendonSheathOfFourthTOE = 284007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metacarpophalangeal joint of index finger")]
        metacarpophalangealJointOfIndexFinger = 289002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fifth metatarsal bone")]
        fifthMetatarsalBone = 301000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plantar surface of great toe")]
        plantarSurfaceOfGreatToe = 311007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of umbilicus")]
        skinOfUmbilicus = 315003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac impression of liver")]
        sss = 318001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ankle")]
        ankle = 344001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Penetrating atrioventricular bundle")]
        penetratingAtrioventricularBundle = 345000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reticular corium")]
        reticularCorium = 356000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wall of urinary bladder")]
        wallOfUrinaryBladder = 393006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental branches of inferior alveolar artery")]
        dentalBranchesOfInferiorAlveolarArtery = 402006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior temporal diploic vein")]
        posteriorTemporalDiploicVein = 405008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastric fundus")]
        gastricFundus = 414003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anastomosis, heterocladic")]
        anastomosisHeterocladic = 420002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior surface of tongue")]
        inferiorSurfaceOfTongue = 422005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trochanteric bursa")]
        trochantericBursa = 446003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Collateral ligament")]
        collateralLigament = 457008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral corticospinal tract")]
        lateralCorticospinalTract = 461002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Basophilic normoblast")]
        basophilicNormoblast = 464005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ascending frontal gyrus")]
        ascendingFrontalGyrus = 465006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Flexor hallucis longus in leg")]
        flexorHallucisLongusInLeg = 471000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiopulmonary circulatory system")]
        cardiopulmonaryCirculatorySystem = 480000,

        /// <summary>
        /// 
        /// </summary>
        [Description("TC - Transverse colon")]
        TC = 485005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Costal surface of lung")]
        costalSurfaceOfLung = 528006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vagus nerve parasympathetic fibers to cardiac plexus")]
        vagusNerveParasympatheticFibersToCardiacPlexus = 552004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc space of fifth lumbar vertebra")]
        intervertebralDiscSpaceOfFifthLumbarVertebra = 565008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of phalanx of great toe")]
        headOfPhalanxOfGreatToe = 582005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Capsule of proximal interphalangeal joint of third toe")]
        capsuleOfProximalInterphalangealJointOfThirdToe = 587004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interventricular septum")]
        interventricularSeptum = 589001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palpebral fissure")]
        palpebralFissuresss = 595000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of philtrum")]
        subcutaneousTissueOfPhiltrum = 608002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Multivesicular body, internal vesicles")]
        multivesicularBodyInternalVesicles = 621009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tuberosity of distal phalanx of little toe")]
        tuberosityOfDistalPhalanxOfLittleToe = 635006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior articular process of seventh thoracic vertebra")]
        superiorArticularProcessOfSeventhThoracicVertebra = 650002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tracheal mucous membrane")]
        trachealMucousMembrane = 660006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Jaw region")]
        jawRegion = 661005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Embryological structure")]
        embryologicalStructure = 667009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal hyaloid artery")]
        fetalHyaloidArtery = 688000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Small intestine submucosa")]
        smallIntestineSubmucosa = 691000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Body of ischium")]
        bodyOfIschium = 692007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dense intermediate filament bundles")]
        denseIntermediateFilamentBundles = 723004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head and neck")]
        headAndNeck = 774007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Visceral surface of liver")]
        visceralSurfaceOfLiver = 790007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep temporal veins")]
        deepTemporalVeins = 798000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior intercostal artery")]
        posteriorIntercostalArtery = 808000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal chondrocranium")]
        fetalChondrocranium = 809008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior cervical spinal cord nerve root")]
        posteriorCervicalSpinalCordNerveRoot = 823005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spinous process of fifth thoracic vertebra")]
        spinousProcessOfFifthThoracicVertebra = 830004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Oral region of face")]
        oralRegionOfFace = 836005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina muscularis of colonic mucous membrane")]
        laminaMuscularisOfColonicMucousMembrane = 885000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior cruciate ligament of knee joint")]
        anteriorCruciateLigamentOfKneeJoint = 895007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior laryngeal aperture")]
        superiorLaryngealAperture = 917004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyrohyoid branch of ansa cervicalis")]
        thyrohyoidBranchOfAnsaCervicalis = 921006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crus of diaphragm")]
        crusOfDiaphragm = 947002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bronchus")]
        bronchus = 955009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ovarian vein")]
        ovarianVein = 976004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Meningeal branch of occipital artery")]
        meningealBranchOfOccipitalArtery = 996007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire diaphragmatic lymph node")]
        entireDiaphragmaticLymphNode = 1005009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of fibrous portion of pericardium")]
        structureOfFibrousPortionOfPericardium = 1012000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of peritonsillar tissue")]
        structureOfPeritonsillarTissue = 1015003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sebaceous gland structure")]
        sebaceousGlandStructure = 1028005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of vesicular bursa of sternohyoid muscle")]
        structureOfVesicularBursaOfSternohyoidMuscle = 1030007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frontozygomatic suture of skull")]
        frontozygomaticSutureOfSkull = 1063000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Promonocyte")]
        promonocyte = 1075005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous prepatellar bursa")]
        subcutaneousPrepatellarBursa = 1076006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Female")]
        female = 1086007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sternothyroid muscle")]
        sternothyroidMuscle = 1087003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior occipital gyrus")]
        superiorOccipitalGyrus = 1092001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thymic cortex")]
        thymicCortex = 1099005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cranial cavity")]
        cranialCavity = 1101003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Major calyx")]
        majorCalyx = 1106008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tarsal gland")]
        tarsalGland = 1110006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior longitudinal muscle of tongue")]
        inferiorLongitudinalMuscleOfTongue = 1122009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aortopulmonary septum")]
        aortopulmonarySeptum = 1136004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frenulum linguae")]
        frenulumLinguae = 1159005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Odontoid process of axis")]
        odontoidProcessOfAxis = 1172006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mandibular nerve")]
        mandibularNerve = 1173001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chromosomes, group E")]
        chromosomesGroupE = 1174007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Teres major muscle")]
        teresMajorMuscle = 1193009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Synostosis")]
        synostosis = 1216008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Central nervous system meninges")]
        centralNervousSystemMeninges = 1231004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Duodenal serosa")]
        duodenalSerosa = 1236009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior articular process of sixth cervical vertebra")]
        inferiorArticularProcessOfSixthCervicalVertebra = 1243003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dorsal digital nerves of radial nerve")]
        dorsalDigitalNervesOfRadialNerve = 1246006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Distinctive arrangement of microtubules")]
        distinctiveArrangementOfMicrotubules = 1263005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vertebral nerve")]
        vertebralNerve = 1277008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Glottis")]
        glottis = 1307006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Telogen hair")]
        telogenHair = 1311000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep flexor tendon of index finger")]
        deepFlexorTendonOfIndexFinger = 1350001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastric serosa")]
        gastricSerosa = 1353004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vastus lateralis muscle")]
        vastusLateralisMuscle = 1403006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior limb of stapes")]
        posteriorLimbOfStapes = 1425000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paravesicular lymph node")]
        paravesicularLymphNode = 1439000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Laryngeal saccule")]
        laryngealSaccule = 1441004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Yellow fibrocartilage")]
        yellowFibrocartilage = 1456008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Parietal branch of superficial temporal artery")]
        parietalBranchOfSuperficialTemporalArtery = 1467009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of metatarsal region of foot")]
        structureOfMetatarsalRegionOfFoot = 1484003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Soft tissues of trunk")]
        softTissuesOfTrunk = 1490004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior cecal artery")]
        anteriorCecalArtery = 1502004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ejaculatory duct")]
        ejaculatoryDuct = 1511004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frontomental diameter of head")]
        frontomentalDiameterOfHead = 1516009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina of fourth thoracic vertebra")]
        laminaOfFourthThoracicVertebra = 1527006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc of eleventh thoracic vertebra")]
        intervertebralDiscOfEleventhThoracicVertebra = 1537001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coccygeal plexus")]
        coccygealPlexus = 1541002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nucleus pulposus of intervertebral disc of third lumbar vertebra")]
        nucleusPulposusOfIntervertebralDiscOfThirdLumbarVertebra = 1562001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nail of third toe")]
        nailOfThirdToe = 1569005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nucleus ventralis lateralis")]
        nucleusVentralisLateralis = 1580005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ileal artery")]
        ilealArtery = 1581009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Symphysis")]
        symphysis = 1584001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Splenius capitis muscle")]
        spleniusCapitisMuscle = 1600003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Histioblast")]
        histioblast = 1605008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Otoconia")]
        otoconia = 1610007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paramammary lymph node")]
        paramammaryLymphNode = 1611006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intrinsic larynx")]
        intrinsicLarynx = 1617005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metaphase nucleus")]
        metaphaseNucleus = 1620002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Third thoracic vertebra")]
        thirdThoracicVertebra = 1626008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial collateral ligament of knee joint")]
        medialCollateralLigamentOfKneeJoint = 1627004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supraorbital vein")]
        supraorbitalVein = 1630006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Foregut")]
        foregut = 1631005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hilum of left lung")]
        hilumOfLeftLung = 1650005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transverse peduncular tract nucleus")]
        transversePeduncularTractNucleus = 1655000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nucleus medialis dorsalis")]
        nucleusMedialisDorsalis = 1659006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligamentum teres of liver")]
        ligamentumTeresOfLiver = 1684009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thymic lobule")]
        thymicLobule = 1706004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ventral nuclear group of thalamus")]
        ventralNuclearGroupOfThalamus = 1707008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Periorbital region")]
        periorbitalRegion = 1711002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cupula ampullaris")]
        cupulaAmpullaris = 1716007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right tonsil")]
        rightTonsil = 1721005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Central tegmental tract")]
        centralTegmentalTract = 1729007,

        /// <summary>
        /// 
        /// </summary>
        [Description("TD - Thoracic duct")]
        TD = 1732005,

        /// <summary>
        /// /
        /// </summary>
        [Description("Structure of lymphatic vessel of thorax")]
        structureOfLymphaticVesselOfThorax = 1765002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Premelanosome")]
        premelanosome = 1780008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sacroiliac region")]
        sacroiliacRegion = 1781007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Naris")]
        naris = 1797002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Greater circulus arteriosus of iris")]
        greaterCirculusArteriosusOfIris = 1818002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Root of nose")]
        rootOfNose = 1825009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Scleral conjunctiva")]
        scleralconjunctiva = 1832000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arrector pili muscle")]
        arrectorPiliMuscle = 1840006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharyngeal recess")]
        pharyngealRecess = 1849007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of suprahyoid muscle")]
        structureOfSuprahyoidMuscle = 1853009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Promontory lymph node")]
        promontoryLymphNode = 1874005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Joint of upper extremity")]
        jointOfUpperExtremity = 1893007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Musculophrenic vein")]
        musculophrenicVein = 1895000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of external ear")]
        skinOfExternalEar = 1902009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ear")]
        ear = 1910005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Suprarenal aorta")]
        suprarenalAorta = 1918003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left elbow")]
        leftElbow = 1927002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Porus acusticus internus")]
        porusAcusticusInternus = 1992003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cingulum dentis")]
        cingulumDentis = 1997009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clavicular facet of scapula")]
        clavicularFacetOfScapula = 2010005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior thoracic artery")]
        superiorThoracicArtery = 2020000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior median fissure of spinal cord")]
        structureOfAnteriorMedianFissureOfSpinalCord = 2031008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right fallopian tube")]
        rightFallopianTube = 2033006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vaginal nerves")]
        vaginalNerves = 2044003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lingual tonsil")]
        lingualTonsil = 2048000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chorionic villi")]
        chorionicVilli = 2049008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of ear lobule")]
        skinOfEarLobule = 2059009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reticular formation of spinal cord")]
        reticularFormationOfSpinalCord = 2071003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of phalanx of hand")]
        headOfPhalanxOfHand = 2076008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nucleus ambiguus")]
        nucleusAmbiguus = 2083001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accessory sinus")]
        accessorySinus = 2095001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mammilloinfundibular nucleus")]
        mammilloinfundibularNucleus = 2123001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urinary tract transitional epithelial cell")]
        urinaryTractTransitionalEpithelialCell = 2150006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Glial cell")]
        glialCell = 2156000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligamentum arteriosum")]
        ligamentumArteriosum = 2160002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pharyngeal cavity")]
        pharyngealCavity = 2175005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endometrial zona basalis")]
        endometrialZonaBasalis = 2182009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clavicular part of pectoralis major muscle")]
        clavicularPartOfPectoralisMajorMuscle = 2192001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina of fifth thoracic vertebra")]
        laminaOfFifthThoracicVertebra = 2205003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebral basal surface")]
        cerebralBasalSurface = 2209009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lesser osseous pelvis")]
        lesserOsseousPelvis = 2236006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Type I hair cell")]
        typeIHairCell = 2246008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subserosa")]
        subserosa = 2255006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of torcular Herophili")]
        structureOfTorcularHerophili = 2285001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of nasopharyngeal gland")]
        structureOfHasopharyngealGland = 2292006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vein of the knee")]
        veinOfTheKnee = 2302002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of spinous process of cervical vertebra")]
        structureOfSpinousProcessOfCervicalVertebra = 2305000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of base of third metacarpal bone")]
        structureOfBaseOfThirdMetacarpalBone = 2306004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Salivary seromucous gland")]
        salivarySeromucousGland = 2327009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of segmental bronchial branches")]
        structureOfSegmentalBronchialBranches = 2330002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metencephalon of foetus")]
        metencephalonOfFoetus = 2332005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Renal calyx")]
        renalCalyx = 2334006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of nasal suture of skull")]
        structureOfNasalSutureOfSkull = 2349003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial surface of toe")]
        structureOfMedialSurfaceOfToe = 2372001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of papillary muscles of right ventricle")]
        structureOfPapillaryMusclesOfRightVentricle = 2383005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior margin of adrenal gland")]
        structureOfSuperiorMarginOfAdrenalGland = 2389009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of transverse facial artery")]
        structureOfTransverseFacialArtery = 2395005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of first metatarsal facet of medial cuneiform bone")]
        structureOfFirstMetatarsalFacetOfMedialCuneiformBone = 2397002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Universal designation 21")]
        universalDesignation21 = 2400006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsum of foot")]
        structureOfDorsumOfFoot = 2402003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of submaxillary ganglion")]
        structureOfSubmaxillaryGanglion = 2421006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of digital tendon and tendon sheath of foot")]
        structureOfDigitalTendonAndTendonSheathOfFoot = 2433001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tunica intima of vein")]
        tunicaIntimaOfVein = 2436009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of posterior surface of forearm")]
        subcutaneousTissueStructureOfPosteriorSurfaceOfForearm = 2453002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of articular surface, third metacarpal, of second metacarpal bone")]
        structureOfArticularSurfaceThirdMetacarpalOfSecondMetacarpalBone = 2454008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin structure of frenulum of clitoris")]
        skinStructureOfFrenulumOfClitoris = 2484000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial check ligament of eye")]
        structureOfMedialCheckLigamentOfEye = 2489005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire cisterna pontis")]
        entireCisternaPontis = 2499000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Membrane of lysosome")]
        membraneOfLysosome = 2502001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of pancreatic plexus")]
        structureOfPancreaticPlexus = 2504000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Femoral triangle structure")]
        femoralTriangleStructure = 2510000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior rectal artery")]
        structureOfSuperiorRectalArtery = 2539000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of cuboid articular facet of fourth metatarsal bone")]
        structureOfCuboidArticularFacetOfFourthMetatarsalBone = 2543001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone structure of phalanx of thumb")]
        boneStructureOfPhalanxOfThumb = 2550002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of gracilis muscle")]
        structureOfGracilisMuscle = 2577006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plasmablast")]
        plasmablast = 2579009,

        /// <summary>
        /// 
        /// </summary>
        [Description("All extremities")]
        allExtremities = 2592007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of flexor pollicis longus muscle tendon")]
        structureOfFlexorPollicisLongusMuscleTendon = 2600000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc structure of third thoracic vertebra")]
        intervertebralDiscStructureOfThirdThoracicVertebra = 2620004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neuroendocrine tissue")]
        neuroendocrineTissue = 2639009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior thalamic radiation of internal capsule")]
        structureOfPosteriorThalamicRadiationOfInternalCapsule = 2653009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of semispinalis capitis muscle")]
        structureOfSemispinalisCapitisMuscle = 2666009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior cutaneous branch of lumbosacral plexus")]
        structureOfAnteriorCutaneousBranchOfLumbosacralPlexus = 2672009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior ethmoidal artery")]
        structureOfAnteriorEthmoidalArtery = 2675006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal nerve of penis")]
        structureOfDorsalNerveOfPenis = 2681003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bladder mucosa")]
        bladderMucosa = 2682005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial olfactory gyrus")]
        structureOfMedialOlfactoryGyrus = 2686008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of Bowman space")]
        structureOfBowmanSpace = 2687004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left maxillary sinus structure")]
        leftMaxillarySinusStructure = 2695000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire calcarine artery")]
        entireCalcarineArtery = 2703009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of capsule of ankle joint")]
        structureOfCapsuleOfAnkleJoint = 2712006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of apical foramen of tooth")]
        structureOfApicalForamenOfTooth = 2718005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of fold for stapes")]
        structureOfFoldForStapes = 2726002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire vitelline vein of placenta")]
        entireVitellineVeinOfPlacenta = 2730004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endometrial structure")]
        endometrialStructure = 2739003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial occipitotemporal gyrus")]
        structureOfMedialOccipitotemporalGyrus = 2741002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Circular layer of gastric muscularis")]
        circularLayerOfGastricMuscularis = 2746007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spinal cord structure")]
        spinalCordStructure = 2748008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Eccrine gland structure")]
        eccrineGlandStructure = 2759004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina propria of ureter")]
        laminaPropriaOfUreter = 2771005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Apocrine gland structure")]
        apocrineGlandStructure = 2789006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of pars tensa of tympanic membrane")]
        structureOfParsTensaOfTympanicMembrane = 2792005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tendon sheath of popliteus muscle")]
        structureOfTendonSheathOfPopliteusMuscle = 2803000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of cremasteric fascia")]
        structureOfCremastericFascia = 2810006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of head of femur")]
        structureOfHeadOfFemur = 2812003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of spinous process of fourth thoracic vertebra")]
        structureOfSpinousProcessOfFourthThoracicVertebra = 2824005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lamina of fourth lumbar vertebra")]
        structureOfLaminaOfFourthLumbarVertebra = 2826007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal digital nerves of lateral hallux and medial second toe")]
        structureOfDorsalDigitalNervesOfLateralHalluxAndMedialSecondToe = 2830005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of perivesicular tissues of seminal vesicles")]
        structureOfPerivesicularTissuesOfSeminalVesicles = 2839006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Renal artery structure")]
        renalArteryStructure = 2841007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of respiratory epithelium")]
        structureOfRespiratoryEpithelium = 2845003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superficial epigastric artery")]
        structureOfSuperficialEpigastricArtery = 2848001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of accessory cephalic vein")]
        structureOfAccessoryCephalicVein = 2855004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire gland (organ)")]
        entireGland = 2861001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior epiglottis")]
        structureOfPosteriorEpiglottis = 2894003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior ligament of uterus")]
        structureOfAnteriorLigamentOfUterus = 2905008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior portion of diaphragmatic aspect of liver")]
        structureOfPosteriorPortionOfDiaphragmaticAspectOfLiver = 2909002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of facial nerve motor branch")]
        structureOfFacialNerveMotorBranch = 2920002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior papillary muscle of left ventricle")]
        structureOfPosteriorPapillaryMuscleOfLeftVentricle = 2922005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of supraorbital area")]
        subcutaneousTissueStructureOfSupraorbitalArea = 2923000,
        /// <summary>
        /// 
        /// </summary>
        [Description("Supernumerary deciduous tooth")]
        supernumeraryDeciduousTooth = 2954001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anatomical space structure")]
        anatomicalSpaceStructure = 2969000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone structure of medial cuneiform")]
        boneStructureOfMedialCuneiform = 2979003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of talar facet of navicular bone of foot")]
        structureOfTalarFacetOfNavicularBoneOfFoot = 2986006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire right margin of uterus")]
        entireRightMarginOfUterus = 2998001,
        /// <summary>
        /// 
        /// </summary>
        [Description("Internal capsule anterior limb structure")]
        internalCapsuleAnteriorLimbStructure = 3003007,

        /// <summary>
        /// 
        /// </summary>
        [Description("White fibrocartilage")]
        whiteFibrocartilage = 3008003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transitional epithelial cell")]
        transitionalEpithelialCell = 3028004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of thigh")]
        subcutaneousTissueStructureOfThigh = 3039001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of glomerular urinary pole")]
        structureOfGlomerularUrinaryPole = 3042007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of articular surface, metacarpal, of phalanx of thumb")]
        structureOfArticularSurfaceMetacarpalOfPhalanxOfThumb = 3054007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of bone marrow of vertebral body")]
        structureOfBoneMarrowOfVertebralBody = 3055008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anteroventral nucleus of thalamus")]
        structureOfAnteroventralNucleusOfThalamus = 3056009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nerve structure")]
        nerveStructure = 3057000,

        /// <summary>
        /// 
        /// </summary>
        [Description("PNS - Peripheral nervous system")]
        peripheralNervousSystem = 3058005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spinal arachnoid")]
        spinalArachnoid = 3062004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of seminal vesicle lumen")]
        structureOfSeminalVesicleLumen = 3068000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mitochondrion in division")]
        mitochondrionInDivision = 3081007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tendinous arch of pelvic fascia")]
        structureOfTendinousArchOfPelvicFascia = 3093003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical crown of tooth")]
        clinicalCrownOfTooth = 3100007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of suprachoroidal space")]
        structureOfSuprachoroidalSpace = 3113001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal surface of index finger")]
        structureOfDorsalSurfaceOfIndexFinger = 3117000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of trabecula carnea of left ventricle")]
        structureOfTrabeculaCarneaOfLeftVentricle = 3118005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pleural membrane structure")]
        pleuralMembraneStructure = 3120008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of head of fourth metatarsal bone")]
        structureOfHeadOfFourthMetatarsalBone = 3134008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone tissue")]
        boneTissue = 3138006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tractus olivocochlearis")]
        structureOfTractusOlivocochlearis = 3153003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of obturator artery")]
        structureOfObturatorArtery = 3156006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of costocervical trunk")]
        structureOfCostocervicalTrunk = 3159004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spinal nerve structure")]
        spinalNerveStructure = 3169005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of raphe of soft palate")]
        structureOfRapheOfSoftPalate = 3178004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocardium of right atrium")]
        endocardiumOfRightAtrium = 3194006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Monostomatic sublingual gland")]
        monostomaticSublingualGland = 3198009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of nuchal region")]
        subcutaneousTissueStructureOfNuchalRegion = 3215002,

        /// <summary>
        /// 
        /// </summary>
        [Description("All large arteries")]
        allLargeArteries = 3222005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left coronary artery main stem")]
        leftCoronaryArteryMainStem = 3227004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior segment of right upper lobe of lung")]
        structureOfPosteriorSegmentOfRightUpperLobeOfLung = 3236000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of parametrial lymph node")]
        structureOfParametrialLymphNode = 3243006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Papillary area")]
        papillaryArea = 3255000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of root canal of tooth")]
        structureOfRootCanalOfTooth = 3262009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of pedicle of third cervical vertebra")]
        structureOfPedicleOfThirdCervicalVertebra = 3279003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of ventral anterior nucleus of thalamus")]
        structureOfVentralAnteriorNucleusOfThalamus = 3295003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tectopontine fibers")]
        tectopontineFibers = 3301002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Splenic branch of splenic artery")]
        splenicBranchOfSplenicArtery = 3302009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of vestibulospinal tract")]
        structureOfVestibulospinalTract = 3315000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occipitofrontal diameter of head")]
        occipitofrontalDiameterOfHead = 3332001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Haversian canal")]
        haversianCanal = 3336003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right lung structure")]
        rightLungStructure = 3341006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire right commissure of pulmonic valve")]
        entireRightCommissureOfPulmonicValve = 3350008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intertragal incisure structure")]
        intertragalIncisureStructure = 3362007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior papillary muscle of left ventricle")]
        structureOfAnteriorPapillaryMuscleOfLeftVentricle = 3366005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of supporting tissue of rectum")]
        structureOfSupportingTissueOfRectum = 3370002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secondary spermatocyte")]
        secondarySpermatocyte = 3374006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of agger nasi")]
        structureOfAggeNasi = 3377004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of rima oris")]
        structureOfRimaOris = 3382006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nonsegmented basophil")]
        nonsegmentedBasophil = 3383001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Suboccipitobregmatic diameter of head")]
        suboccipitobregmaticDiameterOfHead = 3394002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior palpebral arch")]
        structureOfSuperiorPalpebralArch = 3395001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of mesogastrium")]
        structureOfMesogastrium = 3396000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cell of bone")]
        cellOfBone = 3400000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lateral margin of forearm")]
        structureOfLateralMarginOfForearm = 3409004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of rotator muscle")]
        structureOfRotatorMuscle = 3417007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep lymphatic of upper extremity")]
        deepymphaticOfUpperExtremity = 3438001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thalamostriate vein")]
        thalamostriateVein = 3444002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Penetrated oocyte")]
        penetratedOocyte = 3447009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterodorsal nucleus of thalamus")]
        structureOfAnterodorsalNucleusOfThalamus = 3460003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of commissure of tricuspid valve")]
        structureOfCommissureOfTricuspidValve = 3462006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior midline of trunk")]
        posteriorMidlineOfTrunk = 3471002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of vastus medialis muscle")]
        structureOfVastusMedialisMuscle = 3478008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of embryonic testis")]
        structureOfEmbryonicTestis = 3481003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Annulate lamella, cisternal lumen")]
        annulateLamellaCisternalLumen = 3488009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of suboccipital region")]
        subcutaneousTissueStructureOfSuboccipitalRegion = 3490005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lateral wall of mastoid antrum")]
        structureOfLateralWallOfMastoidAntrum = 3524005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of capsule of proximal tibiofibular joint")]
        structureOfCapsuleOfProximalTibiofibularJoint = 3538003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal metatarsal artery")]
        structureOfDorsalMetatarsalArtery = 3541007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of thyroid capsule")]
        structureOfThyroidCapsule = 3553006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal nucleus of trapezoid body")]
        structureOfDorsalNucleusOfTrapezoidBody = 3556003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Muscularis of ureter")]
        muscularisOfUreter = 3563003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vertebral body")]
        vertebralBody = 3572006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of body of gallbladder")]
        structureOfBodyOfGallbladder = 3578005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of gastrophrenic ligament")]
        structureOfGastrophrenicLigament = 3582007,

        /// <summary>
        /// 
        /// </summary>
        [Description("T10 dorsal arch")]
        t10DorsalArch = 3584008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of straight part of longus colli muscle")]
        structureOfStraightPartOfLongusColliMuscle = 3594003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ischiococcygeus muscle")]
        ischiococcygeusMuscle = 3608004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of occipital branch of posterior auricular artery")]
        structureOfOccipitalBranchOfPosteriorAuricularArtery = 3609007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamellipodium")]
        lamellipodium = 3646006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tympanic ostium of Eustachian tube")]
        structureOfTympanicOstiumOfEustachianTube = 3663005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pelvic wall structure")]
        pelvicWallStructure = 3665003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire subpyloric lymph node")]
        entireSubpyloricLymphNode = 3670005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Great vessel")]
        greatVessel = 3711007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lateral thoracic artery")]
        structureOfLateralThoracicArtery = 3743007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of nucleus pulposus of intervertebral disc of first thoracic vertebra")]
        structureOfNucleusPulposusOfIntervertebralDiscOfFirstThoracicVertebra = 3761003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of lower extremity")]
        subcutaneousTissueStructureOfLowerExtremity = 3766008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire dorsal metacarpal ligament")]
        entireDorsalMetacarpalLigament = 3785006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of apical segment of right lower lobe of lung")]
        structureOfApicalSegmentOfRightLowerLobeOfLung = 3788008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Enteroendocrine cell")]
        enteroendocrineCell = 3789000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Septal cartilage structure")]
        septalCartilageStructure = 3810000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of apex of coccyx")]
        structureOfApexOfCoccyx = 3838008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of transplanted liver")]
        structureOfTransplantedLiver = 3860006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of interscapular region of back")]
        structureOfInterscapularRegionOfBack = 3865001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal surface of great toe")]
        structureOfDorsalSurfaceOfGreatToe = 3867009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of femoral region")]
        subcutaneousTissueStructureOfFemoralRegion = 3876002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of common carotid plexus")]
        structureOfCommonCarotidPlexus = 3877006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of lateral surface of fourth toe")]
        subcutaneousTissueStructureOfLateralSurfaceOfFourthToe = 3910004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of occipital lymph node")]
        structureOfOccipitalLymphNode = 3916005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of pericardiophrenic artery")]
        structureOfPericardiophrenicArtery = 3924000,

        /// <summary>
        /// 
        /// </summary>
        [Description("OW - Oval window")]
        ovalWindow = 3931001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of tenth rib structure")]
        headOfTenthRibStructure = 3935005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of entorhinal cortex")]
        structureOfEntorhinalCortex = 3937002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lacrimal sac structure")]
        lacrimalSacStructure = 3954005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of fifth metatarsal articular facet of fourth metatarsal bone")]
        structureOfFifthMetatarsalArticularFacetOfFourthMetatarsalBone = 3956007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of rectus capitis muscle")]
        structureOfRectusCapitisMuscle = 3959000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Olfactory tract structure")]
        olfactoryTractStructure = 3960005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of gyrus of brain")]
        structureOfGyrusOfBrain = 3964001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire parietal branch of anterior cerebral artery")]
        entireParietalBranchOfAnteriorCerebralArtery = 3966004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of concha")]
        subcutaneousTissueStructureOfConcha = 3977005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep vein of clitoris")]
        deepVeinOfClitoris = 3989007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial globus pallidus")]
        structureOfMedialGlobusPallidus = 4015004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chromosomes, group A")]
        chromosomesGroupA = 4019005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior commissure of labium majorum")]
        posteriorCommissureOfLabiumMajorum = 4029003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Eosinophilic progranulocyte")]
        eosinophilicProgranulocyte = 106004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral orbital wall")]
        lateralOrbitalWall = 4061004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of capsule of proximal interphalangeal joint of index finger")]
        structureOfCapsuleOfProximalInterphalangealJointOfIndexFinger = 4066009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of fourth coccygeal vertebra")]
        structureOfFourthCoccygealVertebra = 4072009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire dorsal lingual vein")]
        entireDorsalLingualVein = 4081003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of vagus nerve bronchial branch")]
        structureOfVagusNerveBronchialBranch = 4093007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Macula of the saccule")]
        maculaOfTheSaccule = 4111006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lumbosacral spinal cord central canal structure")]
        lumbosacralSpinalCordCentralCanalStructure = 4117005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior frontal sulcus")]
        structureOfSuperiorFrontalSulcus = 4121003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of artery of extremity")]
        structureOfArteryOfExtremity = 4146003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of palmar surface of little finger")]
        structureOfPalmarSurfaceOfLittleFinger = 4148002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Celiac nervous plexus structure")]
        celiacNervousPlexusStructure = 4150005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abdominal aortic plexus structure")]
        abdominalAorticPlexusStructure = 4158003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hyparterial bronchus")]
        hyparterialBronchus = 4159006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Both lower extremities")]
        bothLowerExtremities = 4180000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire extensor tendon and tendon sheath of fifth toe")]
        entireExtensorTendonAndTendonSheathOfFifthToe = 4193005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Türk cell")]
        türkCell = 4205002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Epithelial cells")]
        epithelialCells = 4212006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of second rib structure")]
        headOfSecondRibStructure = 4215008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone structure of first metacarpal")]
        boneStructureOfFirstMetacarpal = 4247003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior tibial vein")]
        posteriorTibialVein = 4258007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral spinorubral tract")]
        lateralSpinorubralTract = 4268002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of inferior articular process of seventh cervical vertebra")]
        structureOfInferiorArticularProcessOfSeventhCervicalVertebra = 4276000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of middle portion of ileum")]
        structureOfMiddlePortionOfIleum = 4281009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of paracortical area of lymph node")]
        structureOfParacorticalAreaOfLymphNode = 4295007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cartilage canal")]
        cartilageCanal = 4303006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior midline of abdomen")]
        anteriorMidlineOfAbdomen = 4312008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of spinalis muscle")]
        structureOfSpinalisMuscle = 4317002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Protoplasmic astrocyte")]
        protoplasmicAstrocyte = 4328003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Upper jaw region")]
        upperJawRegion = 4335006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of subchorionic space")]
        structureOfSubchorionicSpace = 4352005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lateral surface of little finger")]
        structureOfLateralSurfaceOfLittleFinger = 4358009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stratum spinosum structure")]
        stratumSpinosumStructure = 4360006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Small intestine mucous membrane structure")]
        smallIntestineMucousMembraneStructure = 4369007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of fourth metatarsal facet of lateral cuneiform bone")]
        structureOfFourthMetatarsalFacetOfLateralCuneiformBone = 4371007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of incisure of cartilaginous portion of auditory canal")]
        structureOfIncisureOfCartilaginousPortionOfAuditoryCanal = 4375003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of parafascicular nucleus of thalamus")]
        structureOfParafascicularNucleusOfThalamus = 4377006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Scala vestibuli structure")]
        scalaVestibuliStructure = 4394008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior articular surface for talus")]
        structureOfAnteriorArticularSurfaceForTalus = 4402002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tracheal submucosa")]
        trachealSubmucosa = 4419000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cellular structures")]
        cellularStructures = 4421005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of clivus ossis sphenoidalis")]
        structureOfClivusOssisSphenoidalis = 4430002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of ductus arteriosus")]
        structureOfDuctusArteriosus = 4432005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Dental arch structure")]
        dentalArchStructure = 4442007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of accessory sinus gland")]
        structureOfAccessorySinusGland = 4486002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of subclavian plexus")]
        structureOfSubclavianPlexus = 4524000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Joint structure of lower extremity")]
        jointStructureOfLowerExtremity = 4527007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of internal medullary lamina of thalamus")]
        structureOfInternalMedullaryLaminaOfThalamus = 4537002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamellated granule, as in surfactant-secreting cell")]
        lamellatedGranuleAsInSurfactantSecretingCell = 4548009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire vagus nerve parasympathetic fibers to liver, gallbladder, bile ducts and pancreas")]
        entireVagusNerveParasympatheticFibersToLiverGallbladderBileDuctsAndPancreas = 4549001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tentorium cerebelli")]
        structureOfTentoriumCerebelli = 4566004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Desmosome")]
        desmosome = 4573009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin structure of posterior surface of thigh")]
        skinStructureOfPosteriorSurfaceOfThigh = 4578000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of splenius muscle of trunk")]
        structureOfSpleniusMuscleOfTrunk = 4583008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of middle trunk of brachial plexus")]
        structureOfMiddleTrunkOfBrachialPlexus = 4588004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Larynx structure")]
        larynxStructure = 4596009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of base of phalanx of foot")]
        structureOfBaseOfPhalanxOfFoot = 4603002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tubercle of eighth rib structure")]
        tubercleOfEighthRibStructure = 4606005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lesser tuberosity of humerus")]
        structureOfLesserTuberosityOfHumerus = 4621004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of lymphatic cord")]
        structureOfLymphaticCord = 4624007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lipid droplet, homogeneous")]
        lipidDropletHomogeneous = 4647008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tunica albuginea of corpus spongiosum")]
        structureOfTunicaAlbugineaOfCorpusSpongiosum = 4651005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin structure of nuchal region")]
        skinStructureOfNuchalRegion = 4658004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Basal lamina, inclusion in subepithelial location")]
        basalLaminaInclusionInSubepithelialLocation = 4677002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardinal vein structure")]
        cardinalVeinStructure = 4703008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Neutrophilic myelocyte")]
        neutrophilicMyelocyte = 4717004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire venous plexus of the foramen ovale basis cranii")]
        entireVenousPlexusOfTheForamenOvaleBasisCranii = 4718009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of ventral sacrococcygeal ligament")]
        structureOfVentralSacrococcygealLigament = 4743003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of medial surface of great toe")]
        structureOfMedialSurfaceOfGreatToe = 4755009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of gemellus muscle")]
        structureOfGemellusMuscle = 4759003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of supracardinal vein")]
        structureOfSupracardinalVein = 4766002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of perineal nerve")]
        structureOfPerinealNerve = 4768001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of phrenic nerve pericardial branch")]
        structureOfPhrenicNervePericardialBranch = 4774001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of ventral posterior inferior nucleus")]
        structureOfVentralPosteriorInferiorNucleus = 4775000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deiter cell")]
        deiterCell = 4799000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of uterine venous plexus")]
        structureOfUterineVenousPlexus = 4810005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior tibial compartment structure")]
        anteriorTibialCompartmentStructure = 4812002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Femoral canal structure")]
        femoralCanalStructure = 4828007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of ring finger")]
        subcutaneousTissueStructureOfRingFinger = 4840007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ampulla of semicircular duct")]
        ampullaOfSemicircularDuct = 4843009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of tuberculum impar")]
        structureOfTuberculumImpar = 4861000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Constrictor muscle of pharynx structure")]
        constrictorMuscleOfPharynxStructure = 4866005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal tegmental nuclei of midbrain")]
        structureOfDorsalTegmentalNucleiOfMidbrain = 4870002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina of modiolus of cochlea")]
        laminaOfModiolusOfCochlea = 4871003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire sublingual vein")]
        entireSublingualVein = 4881004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire interlobular vein of kidney")]
        entireInterlobularVeinOfKidney = 4888005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cell membrane, prokaryotic")]
        cellMembraneProkaryotic = 4897009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of uterovaginal plexus")]
        structureOfUterovaginalPlexus = 4905007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mastoid antrum structure")]
        mastoidAntrumStructure = 4906008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebellar gracile lobule")]
        cerebellarGracileLobule = 4924005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lower limb lymph node structure")]
        lowerLimbLymphNodeStructure = 4942000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of radial notch of ulna")]
        structureOfRadialNotchOfUlna = 4954000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue structure of back")]
        subcutaneousTissueStructureOfBack = 4956003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Amygdaloid structure")]
        amygdaloidStructure = 4958002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior temporal sulcus")]
        structureOfSuperiorTemporalSulcus = 5001007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of yellow bone marrow")]
        structureOfYellowBoneMarrow = 5023006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior surface of prostate")]
        structureOfPosteriorSurfaceOfProstate = 5026003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superficial dorsal veins of clitoris")]
        structureOfSuperficialDorsalVeinsOfClitoris = 5046008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of obturator internus muscle ischial bursa")]
        structureOfObturatorInternusMuscleIschialBursa = 5068003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of rugal column")]
        structureOfRugalColumn = 5069006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of infrasternal angle")]
        structureOfInfrasternalAngle = 5076001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of posterior auricular vein")]
        structureOfPosteriorAuricularVein = 5115006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Entire angle of first rib")]
        entireAngleOfFirstRib = 5122003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lens zonules")]
        lensZonules = 5128004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Permanent upper right 6 tooth")]
        permanentUpperRight6Tooth = 5140004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of intervertebral foramen of twelfth thoracic vertebra")]
        structureOfIntervertebralForamenOfTwelfthThoracicVertebra = 5192008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of epithelium of lens")]
        structureOfEpitheliumOfLens = 5194009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of right external carotid artery")]
        structureOfRightExternalCarotidArtery = 5195005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior ileocecal recess")]
        superiorIleocecalRecess = 5204005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frontal vein")]
        frontalVein = 5213007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of uterine ostium of fallopian tube")]
        structureOfUterineOstiumOfFallopianTube = 5225005,


        /// <summary>
        /// 
        /// </summary>
        [Description("Right cerebral hemisphere structure")]
        rightCerebralHemisphereStructure = 5228007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of mucosa of gallbladder")]
        structureOfMucosaOfGallbladder = 5229004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of thoracic intervertebral disc")]
        structureOfThoracicIntervertebralDisc = 5261000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin structure of lateral portion of neck")]
        skinStructureOfLateralPortionOfNeck = 5272005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of foramen singulare")]
        structureOfForamenSingulare = 5279001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of anterior mediastinal lymph node")]
        structureOfAnteriorMediastinalLymphNode = 5296000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of superior pole of kidney")]
        structureOfSuperiorPoleOfKidney = 5324007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bone structure of C4")]
        boneStructureOfC4 = 5329002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of inferior frontal gyrus")]
        structureOfInferiorFrontalGyrus = 5336001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Synaptic specialization, cytoplasmic")]
        synapticSpecializationCytoplasmic = 5347008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of median arcuate ligament of diaphragm")]
        structureOfMedianArcuateLigamentOfDiaphragm = 5362005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hippocampal structure")]
        hippocampalStructure = 5366008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Small intestine muscularis propria")]
        smallIntestineMuscularisPropria = 5379004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior fascia of perineum")]
        superiorFasciaOfPerineum = 5382009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Uterine paracervical lymph node")]
        uterineParacervicalLymphNode = 5394000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Normal fat pad")]
        normalFatPad = 5398002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular process of third lumbar vertebra")]
        articularProcessOfThirdLumbarVertebra = 5403001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sex chromosome Y")]
        sexChromosomeY = 5421003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Apocrine intraepidermal duct")]
        apocrineIntraepidermalDuct = 5427004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep artery of clitoris")]
        deepArteryOfClitoris = 5458003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac incisure of stomach")]
        cardiacIncisureOfStomach = 5459006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lacrimal part of orbicularis oculi muscle")]
        lacrimalPartOfOrbicularisOculiMuscle = 5491007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metacarpophalangeal joint of little finger")]
        etacarpophalangealJointOfLittleFinger = 5493005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior aberrant ductule of epididymis")]
        superiorAberrantDuctuleOfEpididymis = 5498001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hyaloid artery")]
        hyaloidArtery = 5501001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of chin")]
        subcutaneousTissueOfChin = 5520004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tegmental portion of pons")]
        tegmentalPortionOfPons = 5538001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crista marginalis of tooth")]
        cristaMarginalisOfTooth = 5542003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Longitudinal layer of duodenal muscularis propria")]
        longitudinaLayerOfDuodenalMuscularisPropria = 5544002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Alveolar ridge mucous membrane")]
        alveolaRidgeMucousMembrane = 5560003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Singlet")]
        singlet = 5564007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Seventh costal cartilage")]
        seventhCostalCartilage = 5574005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendon of supraspinatus muscle")]
        tendonOfSupraspinatusMuscle = 5580002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Retina of right eye")]
        retinaOfRightEye = 5597008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anulus fibrosus of intervertebral disc of fifth cervical vertebra")]
        anulusFibrosusOfIntervertebralDiscOfFifthCervicalVertebra = 5611001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Navicular facet of intermediate cuneiform bone")]
        navicularFacetOfIntermediateCuneiformBone = 5625000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right visceral pleura")]
        rightVisceralPleura = 5627008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Muscular portion of interventricular septum")]
        muscularPortionOfInterventricularSeptum = 5633004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Canal of stomach")]
        canalOfOtomach = 5643001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fractured membrane P face")]
        fracturedMembranePFace = 5644007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inner surface of seventh rib")]
        innerSurfaceOfSeventhRib = 5653000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Retina")]
        retina = 5665001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lower digestive tract")]
        lowerDigestiveTract = 5668004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lenticular fasciculus")]
        lenticularFasciculus = 5677006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of upper extremity")]
        subcutaneousTissueOfUpperExtremity = 5682004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular part of tubercle of ninth rib")]
        articularPartOfTubercleOfNinthRib = 5696005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of lateral surface of finger")]
        skinOfLateralSurfaceOfFinger = 5697001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Multifidus muscles")]
        multifidusMuscles = 5709001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Submandibular triangle")]
        submandibularTriangle = 5713008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Temporal fossa")]
        temporalFossa = 5717009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendon and tendon sheath of leg and ankle")]
        tendonAndTendonSheathOfLegAndAnkle = 5718004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior cervical lymph node")]
        anteriorCervicaLymphNode = 5727003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of forearm")]
        skinOfForearm = 5742000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of anterior portion of neck")]
        subcutaneousTissueOfAnteriorPortionOfNeck = 5751008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocervical epithelium")]
        endocervicalEpithelium = 5769004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paradidymis")]
        paradidymis = 5780004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diaphragm")]
        diaphragm = 5798000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medium sized neuron")]
        mediumSizedNeuron = 5802004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Angle of seventh rib")]
        angleOfSeventhRib = 5814007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior rectus muscle")]
        superiorRectusMuscle = 5815008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Duodenal fold")]
        duodenalFold = 5816009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Substantia propria of sclera")]
        substantiaPropriaOfSclera = 5825003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior cord of brachial plexus")]
        posteriorCordOfBrachialPlexus = 5828001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior articular process of seventh cervical vertebra")]
        superiorArticularProcessOfSeventhCervicalVertebra = 5847003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Orbital plate of ethmoid bone")]
        orbitalPlateOfEthmoidBone = 5854009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Serosa of urinary bladder")]
        serosaOfUrinaryBladder = 5868002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of lateral border of sole of foot")]
        subcutaneousTissueOfLateralBorderOfSoleOfFoot = 5872003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tuberosity of distal phalanx of hand")]
        tuberosityOfDistalPhalanxOfHand = 5881009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endothelial sieve plate")]
        endothelialSievePlate = 5882002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular surface, third metacarpal, of fourth metacarpal bone")]
        articularSurfaceThirdMetacarpalOfFourthMetacarpalBone = 5889006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior cells of ethmoid sinus")]
        posteriorCellsOfEthmoidSinus = 5890002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior recess of tympanic membrane")]
        superiorRecessOfTympanicMembrane = 5893000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Myotome")]
        myotome = 5898009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular process of twelfth thoracic vertebra")]
        articularProcessOfTwelfthThoracicVertebra = 5923009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bronchial lumen")]
        bronchialLumen = 5926001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Great cardiac vein")]
        greatCardiacVein = 5928000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tensor tympani muscle")]
        tensorTympaniMuscle = 5942008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vestibular vein")]
        vestibularVein = 5943003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior palatine arch")]
        posteriorPalatineArch = 5944009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Capsule of distal interphalangeal joint of third toe")]
        capsuleOfDistalInterphalangealJointOfThirdToe = 5948007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left wrist")]
        leftWrist = 5951000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Eighth rib")]
        eighthRib = 5953002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of eyelid")]
        subcutaneousTissueOfEyelid = 5976004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Episcleral artery")]
        EpiscleralArtery = 5979006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chromosomes, group D")]
        chromosomesGroupD = 5996007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Quadratus lumborum muscle")]
        quadratusLumborumMuscle = 6001004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc of second thoracic vertebra")]
        intervertebralDiscOfSecondThoracicVertebra = 6004007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Circular layer of duodenal muscularis propria")]
        circularLayerOfDuodenalMuscularisPropria = 6006009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mesentery of ascending colon")]
        mesenteryOfAscendingColon = 6009002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Reticuloendothelial system")]
        reticuloendothelialSystem = 6013009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Penicilliary arteries")]
        penicilliaryArteries = 6014003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Heterolysosome")]
        heterolysosome = 6023000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Columnar epithelial cell")]
        columnarEpithelialCell = 6032003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Outer surface of third rib")]
        outerSurfaceOfThirdRib = 6046003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lacrimal vein")]
        lacrimalVein = 6050005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Metacarpophalangeal joint of middle finger")]
        metacarpophalangealjointOfMiddleFinger = 6059006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deciduous mandibular right canine tooth")]
        deciduousMandibularRightCanineTooth = 6062009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligament of left superior vena cava")]
        ligamentOfLeftSuperiorVenaCava = 6073002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Capsule of temporomandibular joint")]
        capsuleOfTemporomandibularJoint = 6074008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastrointestinal subserosa")]
        gastrointestinalSubserosa = 6076005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subclavian nerve")]
        subclavianNerve = 6104005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Body of fifth thoracic vertebra")]
        bodyOfFifthThoracicVertebra = 6105006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Facial nerve parasympathetic fibers")]
        facialNerveParasympatheticFibers = 6110005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nail of fourth toe")]
        nailOfFourthToe = 6194002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Postcapillary venule")]
        postcapillaryVenule = 6216007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Piriform recess")]
        piriformRecess = 6217003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Os lacrimale")]
        osLacrimale = 6229007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sulcus terminalis cordis")]
        sulcusTerminalisCordis = 6253001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accessory phrenic nerves")]
        accessoryPhrenicNerves = 6268000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of scalp")]
        subcutaneousTissueOfScalp = 6269008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of dorsal surface of finger")]
        skinOfDorsalSurfaceOfFinger = 6279005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior basal branch of left pulmonary artery")]
        posteriorBasalBranchOfLeftPulmonaryArtery = 6317000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Aryepiglottic muscle")]
        aryepiglotticMuscle = 6325003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal atloid articulation")]
        fetalAtloidArticulation = 6326002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphoid follicle of stomach")]
        lymphoidFollicleOfStomach = 6335009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hair medulla")]
        hairMedulla = 6359004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphatics of thyroid gland")]
        lymphaticsOfThyroidGland = 6371005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cavernous portion of urethra")]
        cavernousPortionOfUrethra = 6375001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coccygeal nerve")]
        coccygealNerve = 6392005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligamentum nuchae")]
        ligamentumNuchae = 6404004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Presymphysial lymph node")]
        presymphysialLymphNode = 6413002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial malleolus")]
        medialMalleolus = 6417001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supraspinatus muscle")]
        upraspinatusMuscle = 6423006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of radiating portion of cortical lobule of kidney")]
        structureOfRadiatingPortionOfCorticalLobuleOfKidney = 6424000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mast cell")]
        mastCell = 6445007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior vagal trunk")]
        posteriorVagalTrunk = 6448009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cytotrophoblast")]
        cytotrophoblast = 6450001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial aspect of ovary")]
        medialAspectOfOvary = 6472004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Glans clitoridis")]
        glansClitoridis = 6504002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Distal portion of circumflex branch of left coronary artery")]
        distalPortionOfCircumflexBranchOfLeftCoronaryArtery = 6511003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cardiac valve leaflet")]
        cardiacValveLeaflet = 6530003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Colonic haustra")]
        colonicHaustra = 6533001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyrocervical trunk")]
        thyrocervicalTrunk = 6538005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior commissure of mitral valve")]
        anteriorCommissureOfMitralValve = 6541001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastrohepatic ligament")]
        gastrohepaticLigament = 6544009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Angular incisure of stomach")]
        angularIncisureOfStomach = 6550004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pollicis artery")]
        pollicisArtery = 6551000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior nasal turbinate")]
        inferiorNasalTurbinate = 6553002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial border of sole")]
        medialBorderOfSole = 6564004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebellar hemisphere")]
        cerebellarHemisphere = 6566002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Base of phalanx of middle finger")]
        baseOfPhalanxOfMiddleFinger = 6572002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lingual nerve")]
        lingualNerve = 6598008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of dorsal intercuneiform ligaments")]
        structureOfDorsalIntercuneiformLigaments = 6606008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sphenoparietal sinus")]
        sphenoparietalSinus = 6608009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cuticle of nail")]
        cuticleOfNail = 6620001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sternal muscle")]
        sternalMuscle = 6623004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right posterior cerebral artery")]
        rightPosteriorCerebralArtery = 6633007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right anterior cerebral artery")]
        rightAnteriorCerebralArtery = 6643005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior fossa of cranial cavity")]
        anteriorFossaOfCranialCavity = 6646002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Uterine subserosa")]
        uterineSubserosa = 6649009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Central lobule of cerebellum")]
        centralLobuleOfCerebellum = 6651008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular facet of head of fibula")]
        articularFacetOfHeadOfFibula = 6684008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right ankle")]
        rightAnkle = 6685009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arch of second lumbar vertebra")]
        archOfSecondLumbarVertebra = 6711001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Femoral nerve lateral muscular branches")]
        femoralNerveLateralMuscularBranches = 6720005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pleural recess")]
        pleuralRecess = 6731002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Chorda tympani")]
        chordaTympani = 6739000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Callosomarginal branch of anterior cerebral artery")]
        callosomarginalBranchOfAnteriorCerebralArtery = 6742006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mitochondrial inclusion")]
        mitochondrialInclusion = 6750002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right knee")]
        rightKnee = 6757004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendon and tendon sheath of hand")]
        tendonAndTendonSheathOfHand = 6787005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spermatozoa")]
        spermatozoa = 6789008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Macula of utricle")]
        maculaOfUtricle = 6799003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interstitial tissue of spleen")]
        interstitialTissueOfSpleen = 6805009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obturator nerve anterior branch")]
        obturatorNerveAnteriorBranch = 6820003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligament of lumbosacral joint")]
        ligamentOfLumbosacralJoint = 6828005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pars ciliaris of retina")]
        parsCiliarisOfRetina = 6829002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Axial skeleton")]
        axialSkeleton = 6834003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Corticomedullary junction of kidney")]
        corticomedullaryJunctionOfKidney = 6841009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Spore crystal")]
        sporeCrystal = 6844001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secondary foot process")]
        secondaryFootProcess = 6850006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Leaf of epiglottis")]
        leafOfEpiglottis = 6864006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Habenular commissure")]
        habenularCommissure = 6866008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Visceral pericardium")]
        visceralPericardium = 6871001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial surface of arm")]
        medialSurfaceOfArm = 6894000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Popliteal region")]
        poplitealRegion = 6902008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of medial surface of third toe")]
        subcutaneousTissueOfMedialSurfaceOfThirdToe = 6905005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lower alveolar ridge mucosa")]
        lowerAlveolarRidgeMucosa = 6912001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Perivascular space")]
        perivascularSpace = 6914000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right upper extremity")]
        rightUpperExtremity = 6921000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Jugular arch")]
        jugularArch = 6930008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior labial veins")]
        anteriorLabialVeins = 6944002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphocytic tissue")]
        lymphocyticTissue = 6969002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior myocardium")]
        anteriorMyocardium = 6975006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior hypothalamic nucleus")]
        posteriorHypothalamicNucleus = 6981003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Collateral sulcus")]
        collateralSulcus = 6987004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thoracolumbar region of back")]
        thoracolumbarRegionOfBack = 6989001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of jaw")]
        subcutaneousTissueOfJaw = 6991009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Bile duct mucous membrane")]
        bileDuctMucousMembrane = 7035006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of external genitalia")]
        subcutaneousTissueOfExternalGenitalia = 7050002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right colic artery")]
        rightColicArtery = 7067009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interstitial tissue of myocardium")]
        interstitialTissueOfMyocardium = 7076002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Middle phalanx of index finger")]
        middlePhalanxOfIndexFinger = 7083009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supraaortic branches")]
        supraaorticBranches = 7090004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ventral posterolateral nucleus of thalamus")]
        ventralPosterolateralNucleusOfThalamus = 7091000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Attachment plaque of desmosome or hemidesmosome")]
        attachmentPlaqueOfDesmosomeOrHemidesmosome = 7099003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fetal implantation site")]
        fetalImplantationSite = 7117004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Maxillary right second molar tooth")]
        maxillaryRightSecondMolarTooth = 7121006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anulus fibrosus of intervertebral disc of thoracic vertebra")]
        anulusFibrosusOfIntervertebralDiscOfThoracicVertebra = 7148007,

        /// <summary>
        /// 
        /// </summary>
        [Description("False rib")]
        falseRib = 7149004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trigeminal ganglion sensory root")]
        trigeminalGanglionSensoryRoot = 7154008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Base of metacarpal bone")]
        baseOfMetacarpalBone = 7160008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paraduodenal recess")]
        paraduodenalRecess = 7167006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cauda equina")]
        caudaEquina = 7173007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gustatory pore")]
        gustatoryPore = 7188002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Isthmus tympani posticus")]
        isthmusTympaniPosticus = 7192009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hypoglossal nerve intrinsic tongue muscle branch")]
        hypoglossalNerveIntrinsicTongueMuscleBranch = 7227003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior choroid vein")]
        inferiorChoroidVein = 7234001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Appendiceal muscularis propria")]
        appendicealMuscularisPropria = 7242000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphatics of appendix and large intestine")]
        lymphaticsOfAppendixAndLargeIntestine = 7275008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Muscle of perineum")]
        muscleOfPerineum = 7295002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep inguinal ring")]
        deepInguinalRing = 7296001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior surface of arm")]
        anteriorSurfaceOfArm = 7311008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lingual gyrus")]
        lingualGyrus = 7344002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ciliary processes")]
        ciliaryProcesses = 7345001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infratendinous olecranon bursa")]
        infratendinousOlecranonBursa = 7347009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphatic of head")]
        lymphaticOfHead = 7362006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left margin of uterus")]
        leftMarginOfUterus = 7376007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paraventricular nucleus of thalamus")]
        paraventricularNucleusOfThalamus = 7378008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plantar calcaneocuboidal ligament")]
        plantarCalcaneocuboidalLigament = 7384006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior semicircular duct")]
        anteriorSemicircularDuct = 7404008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ovarian ligament")]
        ovarianLigament = 7435002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral surface of sublingual gland")]
        lateralSurfaceOfSublingualGland = 7471001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lipid, crystalline")]
        lipidCrystalline = 7477002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Iliotibial tract")]
        iliotibialTract = 7480001,


        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebellar lenticular nucleus")]
        cerebellarLenticularNucleus = 7494000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plantar tarsal ligaments")]
        plantarTarsalLigaments = 7498002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior ligament of head of fibula")]
        anteriorLigamentOfHeadOfFibula = 7507003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vasa vasorum")]
        vasaVasorum = 7524009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vagus nerve parasympathetic fibers")]
        vagusNerveParasympatheticFibers = 7532001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep head of flexor pollicis brevis muscle")]
        deepHeadOfFlexorPollicisBrevisMuscle = 7554004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mitotic cell in anaphase")]
        mitoticCellInAnaphase = 7566005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Finger")]
        finger = 7569003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc space of eleventh thoracic vertebra")]
        intervertebralDiscSpaceOfEleventhThoracicVertebra = 7591005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of vertex")]
        subcutaneousTissueOfVertex = 7597009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Connexon")]
        connexon = 7605000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tenth thoracic vertebra")]
        tenthThoracicVertebra = 7610001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thalamoolivary tract")]
        thalamoolivaryTract = 7629007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervenous tubercle of right atrium")]
        intervenousTubercleOfRightAtrium = 7651004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Frenulum labii")]
        frenulumLabii = 7652006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Femoral artery")]
        femoralArtery = 7657000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subtendinous bursa of triceps brachii muscle")]
        subtendinousBursaOfTricepsBrachiiMuscle = 7658005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pontine portion of medial longitudinal fasciculus")]
        pontinePortionOfMedialLongitudinalFasciculus = 7697002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subdural space of spinal region")]
        subduralSpaceOfSpinalRegion = 7712004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of medial surface of fifth toe")]
        skinOfMedialSurfaceOfFifthToe = 7726008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior choroidal artery")]
        posteriorChoroidalArtery = 7736000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palatine duct")]
        palatineDuct = 7742001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin appendage")]
        skinAppendage = 7748002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mesovarian margin of ovary")]
        mesovarianMarginOfOvary = 7755000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina of third thoracic vertebra")]
        laminaOfThirdThoracicVertebra = 7756004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Striate artery")]
        striateArtery = 7764005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right foot")]
        rightFoot = 7769000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sympathetic trunk spinal nerve branch")]
        sympatheticTrunkSpinalNerveBranch = 7783003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral posterior nucleus of thalamus")]
        lateralPosteriorNucleusOfThalamus = 7820009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior surface of manubrium")]
        anteriorSurfaceOfManubrium = 7829005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abdominal aorta")]
        abdominalAorta = 7832008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior margin of nasal septum")]
        posteriorMarginOfNasalSeptum = 7835005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of submental area")]
        subcutaneousTissueOfSubmentalArea = 7840002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Macrocytic normochromic erythrocyte")]
        macrocyticNormochromicErythrocyte = 7841003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sternoclavicular joint")]
        sternoclavicularJoint = 7844006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intracranial subdural space")]
        intracranialSubduralSpace = 7851002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mandibular canal")]
        mandibularCanal = 7854005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Myocardium of ventricle")]
        myocardiumOfVentricle = 7872004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Scapular region of back")]
        scapularRegionOfBack = 7874003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rhopheocytotic vesicle")]
        rhopheocytoticVesicle = 7880006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Corneal corpuscle")]
        cornealCorpuscle = 7884002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rotator cuff including muscles and tendons")]
        rotatorCuffIncludingMusclesAndTendons = 7885001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Submucosa of anal canal")]
        submucosaOfAnalCanal = 7892006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Occipital angle of parietal bone")]
        occipitalAngleOfParietalBone = 7896009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Olivocerebellar fibers")]
        olivocerebellarFibers = 7911004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Proximal phalanx of third toe")]
        proximalPhalanxOfThirdToe = 7925003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligament of diaphragm")]
        ligamentOfDiaphragm = 7936005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Helper cell")]
        helperCell = 7944005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina propria of ethmoid sinus")]
        laminaPropriaOfEthmoidSinus = 7954009,

        /// <summary>
        /// 
        /// </summary>
        [Description("First left aortic arch")]
        firstLeftAorticArch = 7967007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abdominopelvic portion of sympathetic nervous system")]
        abdominopelvicPortionOfSympatheticNervousSystem = 7986004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of glans penis")]
        skinOfGlansPenis = 7991003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articulations of auditory ossicles")]
        articulationsOfAuditoryOssicles = 7999001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mucous membrane of tongue")]
        mucousMembraneOfTongue = 8001006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Anterior communicating artery")]
        anteriorCommunicatingArtery = 8012006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inflow tract of right ventricle")]
        inflowTractOfRightVentricle = 8017000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Limitans nucleus")]
        limitansNucleus = 8024004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous acromial bursa")]
        subcutaneousAcromialBursa = 8039003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superficial flexor tendon of little finger")]
        superficialFlexorTendonOfLittleFinger = 8040001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Membrane-coating granule, amorphous")]
        membraneCoatingGranuleAmorphous = 8045006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral nuclei of globus pallidus")]
        lateralNucleiOfGlobusPallidus = 8057002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pancreatic veins")]
        pancreaticVeins = 8059004,

        /// <summary>
        /// /
        /// </summary>
        [Description("Superficial circumflex iliac vein")]
        superficialCircumflexIliacVein = 8067007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stratum lemnisci of corpora quadrigemina")]
        stratumLemnisciOfCorporaQuadrigemina = 8068002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Radial nerve")]
        radialNerve = 8079007,

        /// <summary>
        /// 
        /// </summary>
        [Description("intervertebral disc space of twelfth thoracic vertebra")]
        intervertebralDiscSpaceOfTwelfthThoracicVertebra = 8091003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infundibulum of Fallopian tube")]
        infundibulumOfFallopianTube = 8100009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intranuclear crystal")]
        intranuclearCrystal = 8111001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hindgut")]
        hindgut = 8112008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Delphian lymph node")]
        delphianLymphNode = 8119004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Supraaortic valve area")]
        supraaorticValveArea = 8128003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior anastomotic vein")]
        superiorAnastomoticVein = 8133004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vein of head")]
        veinOfHead = 8157004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interlobar duct of pancreas")]
        interlobarDuctOfPancreas = 8158009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior colliculus of corpora quadrigemina")]
        superiorColliculusOfCorporaQuadrigemina = 8159001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral striate arteries")]
        lateralStriateArteries = 8160006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infraorbital nerve")]
        infraorbitalNerve = 8161005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior articular process of fifth thoracic vertebra")]
        superiorArticularProcessOfFifthThoracicVertebra = 8165001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Wrist")]
        wrist = 8205005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accessory atrioventricular bundle")]
        accessoryAtrioventricularBundle = 8225009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Apical branch of right pulmonary artery")]
        apicalBranchOfRightPulmonaryArtery = 8242003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Osseous portion of Eustachian tube")]
        osseousPortionOfEustachianTube = 8251006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tunica interna of eyeball")]
        tunicaInternaOfEyeball = 8264007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Articular surface, metacarpal, of phalanx of hand")]
        articularSurfaceMetacarpalOfPhalanxOfHand = 8265008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Small intestine serosa")]
        smallIntestineSerosa = 8266009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pelvic viscus")]
        pelvicViscus = 8279000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Below knee region")]
        belowKneeRegion = 8289001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interlobular arteries of liver")]
        interlobularArteriesOfLiver = 8292002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mastoid fontanel of skull")]
        mastoidFontanelOfSkull = 8314003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lumbar lymph node")]
        lumbarLymphNode = 8334002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Colic lymph node")]
        colicLymphNode = 8356004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tunica intima")]
        tunicaIntima = 8361002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sphincter pupillae muscle")]
        sphincterPupillaeMuscle = 8369000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Jugum of sphenoid bone")]
        jugumOfSphenoidBone = 8373002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lamina of eighth thoracic vertebra")]
        laminaOfEighthThoracicVertebra = 8387002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Birth canal")]
        birthCanal = 8389004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Iliac fossa")]
        iliacFossa = 8412003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Renal surface of adrenal gland")]
        renalSurfaceOfAdrenalGland = 8415001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Joint of lumbar vertebra")]
        jointOfLumbarVertebra = 8454000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ligament of sacroiliac joint and pubic symphysis")]
        ligamentOfSacroiliacJointAndPubicSymphysis = 8464009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Sinoatrial node branch of right coronary artery")]
        sinoatrialNodeBranchOfRightCoronaryArtery = 8482007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mesial surface of tooth")]
        mesialSurfaceOfTooth = 8483002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Obliquus capitis muscle")]
        obliquusCapitisMuscle = 8496001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior articular process of twelfth thoracic vertebra")]
        inferiorArticularProcessOfTwelfthThoracicVertebra = 8523001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior intercavernous sinus")]
        posteriorIntercavernousSinus = 8546004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lipid droplet")]
        lipidDroplet = 8556000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Juxtaintestinal lymph node")]
        juxtaintestinalLymphNode = 8559007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interclavicular ligament")]
        interclavicularLigament = 8560002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Abdominal lymph nodes")]
        abdominalLymphNodes = 8568009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Both feet")]
        bothFeet = 8580001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Meissner's plexus")]
        meissnersPlexus = 8595004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Acoustic nerve")]
        acousticNerve = 8598002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cricoid cartilage")]
        cricoidCartilage = 8600008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adductor hallucis muscle")]
        adductorHallucisMuscle = 8603005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medulla oblongata fasciculus cuneatus")]
        medullaOblongataFasciculusCuneatus = 8604004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right margin of heart")]
        rightMarginOfHeart = 8608001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Zygomatic region of face")]
        zygomaticRegionOfFace = 8617001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transplanted ureter")]
        transplantedUreter = 8623006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior right pulmonary vein")]
        superiorRightPulmonaryVein = 8629005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Choroidal branches of posterior spinal artery")]
        choroidalBranchesOfPosteriorSpinalArtery = 8640002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Glycogen vacuole")]
        glycogenVacuole = 8668003,

        /// <summary>
        /// 
        /// </summary>
        [Description("All toes")]
        allToes = 8671006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Body of right atrium")]
        bodyOfRightAtrium = 8677005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral olfactory gyrus")]
        lateralOlfactoryGyrus = 8688004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral foramen of second lumbar vertebra")]
        intervertebralForamenOfSecondLumbarVertebra = 8695008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Minor sublingual ducts")]
        minorSublingualDucts = 8710005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Periodontal tissues")]
        periodontalTissues = 8711009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of interdigital space of hand")]
        subcutaneousTissueOfInterdigitalSpaceOfHand = 8714001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cavernous portion of internal carotid artery")]
        cavernousPortionOfInternalCarotidArtery = 8752000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nail of second toe")]
        nailOfSecondToe = 8770002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendinous arch")]
        tendinousArch = 8775007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intranuclear body, granular with filamentous capsule")]
        intranuclearBodyGranularWithFilamentousCapsule = 8784007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Corticomedullary junction of adrenal gland")]
        corticomedullaryJunctionOfAdrenalGland = 8810002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Iliac tuberosity")]
        iliacTuberosity = 8814006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thenar and hypothenar spaces")]
        thenarAndHypothenarSpaces = 8815007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pedicle of eleventh thoracic vertebra")]
        pedicleOfEleventhThoracicVertebra = 8820007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Peroneal artery")]
        peronealArtery = 8821006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shaft of phalanx of middle finger")]
        shaftOfPhalanxOfMiddleFinger = 8827005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Agranular endoplasmic reticulum, connection with other organelle")]
        agranularEndoplasmicReticulumConnectionWithOtherOrganelle = 8839002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subtendinous prepatellar bursa")]
        subtendinousPrepatellarBursa = 8845005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Proper fasciculus")]
        properFasciculus = 8850004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Crista galli")]
        cristaGalli = 8854008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Palmar surface of middle finger")]
        palmarSurfaceOfMiddleFinger = 8862000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Mandibular right second premolar tooth")]
        mandibularRightSecondPremolarTooth = 8873007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Brachiocephalic vein")]
        brachiocephalicVein = 8887007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Diaphragmatic surface of lung")]
        diaphragmaticSurfaceOfLung = 8892009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastric cardiac gland")]
        gastricCardiacGland = 8894005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral glossoepiglottic fold")]
        lateralGlossoepiglotticFold = 8897003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left ulnar artery")]
        leftUlnarArtery = 8907008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inferior transverse scapular ligament")]
        inferiorTransverseScapularLigament = 8910001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Endocardium of right ventricle")]
        endocardiumOfRightVentricle = 8911002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Inguinal lymph node")]
        inguinalLymphNode = 8928004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coracoid process of scapula")]
        coracoidProcessOfScapula = 8931003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebral meninges")]
        cerebralMeninges = 8935007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Trapezoid ligament")]
        trapezoidLigament = 8942007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Stratum zonale of corpora quadrigemina")]
        stratumZonaleOfCorporaQuadrigemina = 8965002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left eye")]
        leftEye = 8966001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Joint structure of vertebral column")]
        jointStructureOfVertebralColumn = 8983005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Marginal part of orbicularis oris muscle")]
        marginalPartOfOrbicularisOrisMuscle = 8988001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hepatic vein")]
        hepaticVein = 8993003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cerebellar peduncle")]
        cerebellarPeduncle = 9000002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left parietal lobe")]
        leftParietalLobe = 9003000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Middle colic vein")]
        middleColicVein = 9018004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ascending colon")]
        ascendingColon = 9040008,

        /// <summary>
        /// 
        /// </summary>
        [Description("BothForearms")]
        bothForearms = 9055004,

        /// <summary>
        /// 
        /// </summary>
        [Description("White matter of insula")]
        whiteMatterOfInsula = 9073001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Splenic sinusoids")]
        splenicSinusoids = 9081000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior laryngeal vein")]
        superiorLaryngealVein = 9086005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Arch of foot")]
        archOfFoot = 9089003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Vein of the scala tympani")]
        veinOfTheScalaTympani = 9108007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transverse folds of palate")]
        transverseFoldsOfPalate = 9127001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Embryo stage 1")]
        embryoStage1 = 9156001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Accessory carpal bone")]
        accessoryCarpalBone = 9181003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Capsule of metatarsophalangeal joint of fifth toe")]
        capsuleOfMetatarsophalangealJointOfFifthToe = 9185007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Filaments of contractile apparatus")]
        filamentsOfContractileApparatus = 9186008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral disc of eighth thoracic vertebra")]
        intervertebralDiscOfEighthThoracicVertebra = 9188009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Centriole")]
        centriole = 9208002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Shaft of fifth metatarsal bone")]
        shaftOfFifthMetatarsalBone = 9212008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rotatores lumborum muscles")]
        rotatoresLumborumMuscles = 9229006,

        /// <summary>
        /// 
        /// </summary>
        [Description("External pudendal veins")]
        externalPudendalVeins = 9231002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Niemann-Pick cell")]
        niemannPickCell = 9240003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior segment of right lobe of liver")]
        posteriorSegmentOfRightLobeOfLiver = 9242006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gravid uterus")]
        gravidUterus = 9258009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendon and tendon sheath of second toe")]
        tendonAndTendonSheathOfSecondToe = 9261005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fascia of pelvis")]
        fasciaOfPelvis = 9262003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Corpus cavernosum of penis")]
        corpusCavernosumOfPenis = 9284003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior intraoccipital synchondrosis")]
        posteriorIntraoccipitalSynchondrosis = 9290004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Labial veins")]
        labialVeins = 9305001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Merkel's tactile disc")]
        merkelsTactileDisc = 9317004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subtendinous iliac bursa")]
        subtendinousIliacBursa = 9320007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tail of epididymis")]
        tailOfEpididymis = 9321006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interdental papilla of gingiva")]
        interdentalPapillaOfGingiva = 9325002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral ligament of temporomandibular joint")]
        lateralLigamentOfTemporomandibularJoint = 9332006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skin of medial surface of middle finger")]
        skinOfMedialSurfaceOfMiddleFinger = 9348007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Permanent teeth")]
        permanentTeeth = 9379006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pecten ani")]
        pectenAni = 9380009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lumbar vein")]
        lumbarVein = 9384000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lymphatics of stomach")]
        lymphaticsOfStomach = 9390001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Plantar surface of fourth toe")]
        plantarSurfaceOfFourthToe = 9432007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Structure of deep cervical lymphatic vessel")]
        structureOfDeepCervicalLymphaticVessel = 9438006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subclavian vein")]
        subclavianVein = 9454009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial cartilaginous lamina of Eustachian tube")]
        medialCartilaginousLaminaOfEustachianTube = 9455005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Amacrine cells of retina")]
        amacrineCellsOfRetina = 9475001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Afferent glomerular arteriole")]
        afferentGlomerularArteriole = 9481009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pulmonary ligament")]
        pulmonaryLigament = 9490002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of metacarpal bone")]
        headOfMetacarpalBone = 9498009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Coronal depression of tooth")]
        coronalDepressionOfTooth = 9502002,
        /// <summary>
        /// 
        /// </summary>
        [Description("Calcaneocuboidal ligament")]
        calcaneocuboidalLigament = 9512009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Pyramid of medulla oblongata")]
        pyramidOfMedullaOblongata = 9535007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Facet for fifth costal cartilage of sternum")]
        facetForFifthCostalCartilageOfSternum = 9558005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Duodenal lumen")]
        duodenalLumen = 9566001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of areola")]
        subcutaneousTissueOfAreola = 9568000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep branch of ulnar nerve")]
        deepBranchOfUlnarNerve = 9596006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior process of nasal septal cartilage")]
        posteriorProcessOfNasalSeptalCartilage = 9609000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lanugo hair")]
        lanugoHair = 9625005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left superior vena cava")]
        leftSuperiorVenaCava = 9642004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior transverse scapular ligament")]
        superiorTransverseScapularLigament = 9646001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Gastric mucous gland")]
        gastricMucousGland = 9654004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Infraclavicular lymph nodes")]
        infraclavicularLymphNodes = 9659009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Subcutaneous tissue of lower margin of nasal septum")]
        subcutaneousTissueOfLowerMarginOfNasalSeptum = 9662007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ciliary muscle")]
        ciliaryMuscle = 9668006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Head of second metatarsal bone")]
        headOfSecondMetatarsalBone = 9677004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Melanocyte")]
        melanocyte = 9683001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior scrotal branches of internal pudendal artery")]
        posteriorScrotalBranchesOfInternalPudendalArtery = 9684007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Iliac fascia")]
        iliacFascia = 9708001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Medial supraclavicular nerves")]
        medialSupraclavicularNerves = 9732008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right wrist")]
        rightWrist = 9736006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Tendon of index finger")]
        tendonOfIndexFinger = 9743000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Submucosa of tonsil")]
        submucosaOfTonsil = 9758008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Genital tubercle")]
        genitalTubercle = 9770007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Left carotid sinus")]
        leftCarotidSinus = 9775002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Distinctive shape of mitochondrial cristae")]
        distinctiveShapeOfMitochondrialCristae = 9779008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superficial lymphatics of thorax")]
        superficialLymphaticsOfThorax = 9783008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep venous system of lower extremity")]
        deepVenousSystemOfLowerExtremity = 9791004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Skeletal muscle fiber, type IIb")]
        skeletalMuscleFiberTypeIIb = 9796009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fascia of upper extremity")]
        fasciaOfUpperExtremity = 9813009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Proximal phalanx of little toe")]
        proximalPhalanxOfLittleToe = 9825007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Perforating branches of internal thoracic artery")]
        perforatingBranchesOfInternalThoracicArtery = 9837009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Biparietal diameter of head")]
        biparietalDiameterOfHead = 9840009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Interspinalis thoracis muscles")]
        interspinalisThoracisMuscles = 9841008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Right kidney")]
        rightKidney = 9846003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Hilum of adrenal gland")]
        hilumOfAdrenalGland = 9847007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Fornix of lacrimal sac")]
        fornixOfLacrimalSac = 9849005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Carunculae hymenales")]
        carunculaeHymenales = 9870004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thymus")]
        thymus = 9875009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Appendicular vein")]
        appendicularVein = 9878006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Thyroid tubercle")]
        thyroidTubercle = 9880000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Peripheral nerve myelinated nerve fiber")]
        peripheralNerveMyelinatedNerveFiber = 9881001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transverse arytenoid muscle")]
        transverseArytenoidMuscle = 9891007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Paracentral lobule")]
        paracentralLobule = 9898001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Posterior ethmoidal nerve")]
        posteriorEthmoidalNerve = 9951005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Primary foot process")]
        primaryFootProcess = 9968009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ileocecal ostium")]
        ileocecalOstium = 9970000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Rhomboideus cervicis muscle")]
        rhomboideusCervicisMuscle = 9976006,

        /// <summary>
        /// 
        /// </summary>
        [Description("Superior articular process of sixth thoracic vertebra")]
        superiorArticularProcessOfSixthThoracicVertebra = 9994000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Duodenal ampulla")]
        duodenalAmpulla = 9999005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Lateral meniscus of knee joint")]
        lateralMeniscusOfKneeJoint = 10013000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Base of lung")]
        baseOfLung = 10024003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Base of phalanx of index finger")]
        baseOfPhalanxOfIndexFinger = 10025002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ventral spinocerebellar tract of pons")]
        ventralSpinocerebellarTractOfPons = 10026001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Nucleus pulposus of intervertebral disc of eighth thoracic vertebra")]
        nucleusPulposusOfIntervertebralDiscOfEighthThoracicVertebra = 10036009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intervertebral foramen of fifth thoracic vertebra")]
        intervertebralForamenOfFifthThoracicVertebra = 10042008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Transplanted lung")]
        transplantedLung = 10047002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Male")]
        male = 10052007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Ophthalmic nerve")]
        ophthalmicNerve = 10056005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Levator labii superioris muscle")]
        levatorLabiiSuperiorisMuscle = 10062000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Deep volar arch of radial artery")]
        deepVolarArchOfRadialArtery = 10119003,


        /// 
        /// 
        [Description("Deep dorsal sacrococcygeal ligament")]
        deepDorsalSacrococcygealLigament = 10124000


    }
}
