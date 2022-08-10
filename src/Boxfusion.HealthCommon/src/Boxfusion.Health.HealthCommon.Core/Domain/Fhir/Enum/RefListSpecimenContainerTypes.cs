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
    
    [ReferenceList("Fhir", "SpecimenContainerTypes")]
    public enum RefListSpecimenContainerTypes : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Cytology brush, device")]
        cytologyBrushDevice = 22566001,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Pleural drainage system fluid collector")]
        PleuralDrainageSystemFluidCollector = 463568005,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Paediatric blood donor set")]
        PaediatricBloodDonorSet = 464527005,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Assisted reproduction needle, reprocessed")]
        AssistedReproductionNeedleReprocessed = 464573007,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Assisted reproduction catheter")]
        AssistedReproductionCatheter = 464784003,

        /// <summary>
        /// /
        /// </summary>
        [Description("Assisted reproduction needle, single-use")]
        AssistedReproductionNeedleSingleUse = 464946000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Assisted reproduction cryotube")]
        AssistedReproductionCryotube = 465046006,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue extraction bag")]
        TissueExtractionBag = 465091002,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Otological bone particle collector")]
        OtologicalBoneParticleCollector = 465141003,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Rigid endotherapy cytology brush, reusable")]
        RigidEndotherapyCytologyBrushReusable = 465487000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Rigid endotherapy cytology brush, single-use")]
        RigidEndotherapyCytologyBrushSingleUse = 466164006, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Viscerotome")]
        Viscerotome = 466421006,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood-processing autotransfusion system container")]
        BloodProcessingAutotransfusionSystemContainer = 466447002,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood gas syringe/needle, sodium heparin")]
        BloodGasSyringeNeedleSodiumHeparin = 466623002,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, quad-pack")]
        BloodDonorSetQuadPack = 466637006,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood collection/fat content reduction device")]
        BloodCollectionFatContentReductionDevice = 466704003,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, double-pack")]
        BloodDonorSetDoublePack = 466844004,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, quin-pack")]
        BloodDonorSetQuinPack = 466898000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, triple-pack")]
        BloodDonorSetTriplePack = 466930006,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood gas syringe/needle, lithium heparin")]
        BloodGasSyringeNeedleLithiumHeparin = 467030004,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood autotransfusion system tubing")]
        BloodAutotransfusionSystemTubing = 467131002,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, single-pack")]
        BloodDonorSetSinglePack = 467132009,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set, many-pack")]
        BloodDonorSetManyPack = 467141004, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Cervical cytology inflatable collector")]
        CervicalCytologyInflatableCollector = 467182004, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Adipose tissue stem cell recovery unit")]
        AdiposeTissueStemCellRecoveryUnit = 467330006,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Abortion suction system collection bottle")]
        AbortionSuctionSystemCollectionBottle = 467431009,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Chorionic villus sampling catheter")]
        ChorionicVillusSamplingCatheter = 467499008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cryostat microtome")]
        CryostatMicrotome = 467647004, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Cytology scraper, single-use")]
        CytologyScraperSingleUse = 467697000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Bone marrow explant needle")]
        BoneMarrowExplantNeedle = 467743009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cytology scraper, reusable")]
        CytologyScraperReusable = 467967005,
        

        /// <summary>
        /// 
        /// </summary>
        [Description("Capillary blood collection tube, no-additive")]
        CapillaryBloodCollectionTubeNoAdditive = 467989009,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Bone marrow collection/transfusion set")]
        BoneMarrowCollectionTransfusionSet = 468076003,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Cervical cytology brush")]
        CervicalCytologyBrush = 468131000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Epididymal fluid aspiration catheter")]
        EpididymalFluidAspirationCatheter = 468200003,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Dental bone particle collector")]
        DentalBoneParticleCollector = 468981005,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Endometrial cytology brush")]
        EndometrialCytologyBrush = 468999002,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Intrauterine secretion scoop")]
        IntrauterineSecretionScoop = 469287008,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Intravascular catheter endoluminal brush")]
        IntravascularCatheterEndoluminalBrush = 469322002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Intrauterine scoop")]
        IntrauterineScoop = 469454007,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Flexible endotherapy cytology brush, single-use")]
        FlexibleEndotherapyCytologyBrushSingleUse = 469822008,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Flexible endotherapy cytology brush, reusable")]
        FlexibleEndotherapyCytologyBrushReusable = 470114007,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("General-purpose cytology brush")]
        GeneralPurposeCytologyBrush = 470547006, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Gastro-urological scoop")]
        GastroUrologicalScoop = 470597005, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue/fluid collection bag, sterile")]
        TissuFluidCollectionBagSterile = 700855008,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Specimen container mailer, insulated")]
        SpecimenContainerMailerInsulated = 700905004,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Specimen container mailer, non-insulated")]
        SpecimenContainerMailerNonInsulated = 700906003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood cell freeze/thaw system set")]
        BloodCellFreezeThawSystemSet = 700945008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood collection Luer-syringe adaptor")]
        BloodCollectionLuerSyringeAdaptor = 700955007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood collection needle, basic")]
        BloodCollectionNeedleBasic = 700956008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood/tissue storage/culture container")]
        BloodTissueStorageCultureContainer = 700957004, 

        /// <summary>
        /// 
        /// </summary>
        [Description("General specimen receptacle transport container")]
        GeneralSpecimenReceptacleTransportContainer = 701394007,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube transport container")]
        EvacuatedBloodCollectionTubeTransportContainer = 701516009, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Tissue/fluid collection bag, non-sterile")]
        TissueFluidCollectionBagNonSterile = 701720006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood collection Luer adaptor")]
        BloodCollectionLuerAdaptor = 702120003, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Sputum specimen container")]
        SputumSpecimenContainer = 702223006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Midstream urine specimen container")]
        MidstreamUrineSpecimenContainer = 702224000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Sweat specimen container IVD")]
        SweatSpecimenContainerIVD = 702232008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Sterile urine specimen container")]
        SterileUrineSpecimenContainer = 702244006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, no additive")]
        NonEvacuatedBloodCollectionTubeNoAdditive = 702256007, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-sterile urine specimen container IVD")]
        NonSterileUrineSpecimenContainerIVD = 702264001, 

        /// <summary>
        /// 
        /// </summary>
        [Description("General specimen container, no additive, non-sterile")]
        GeneralSpecimenContainerNoAdditiveNonSterile = 702268003, 

        /// <summary>
        /// 
        /// </summary>
        [Description("General specimen container, no additive, sterile")]
        GeneralSpecimenContainerNoAdditiveSterile = 702269006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood collection tube, ammonium heparin")]
        MicrocapillaryBloodCollectionTubeAmmoniumHeparin = 702275002, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood collection tube, K2EDTA")]
        MicrocapillaryBloodCollectionTubeK2EDTA = 702276001, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood collection tube, no additive")]
        MicrocapillaryBloodCollectionTubeNoAdditive = 702277005, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube, no additive/metal-free")]
        EvacuatedBloodCollectionTubeNoAdditiveMetalFree = 702278000, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube, gel separator")]
        EvacuatedBloodCollectionTubeGelSeparator = 702279008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube, RNA stabilizer")]
        EvacuatedBloodCollectionTubeRNAStabilizer = 702280006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube, thrombin/clot activator/gel separator")]
        EvacuatedBloodCollectionTubeThrombinClotActivatorGelSeparator = 702281005, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, EDTA")]
        NonEvacuatedBloodCollectionTubeEDTA = 702282003, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, gel separator")]
        NonEvacuatedBloodCollectionTubeGelSeparator = 702283008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, lithium heparin")]
        NonEvacuatedBloodCollectionTubeLithiumHeparin = 702284002, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, lithium heparin/gel separator, sterile")]
        NonEvacuatedBloodCollectionTubeLithiumHeparinGelSeparatorSterile = 702285001,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, NaEDTA/sodium fluoride")]
        NonEvacuatedBloodCollectionTubeNaEDTASodiumFluoride = 702286000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, potassium oxalate/sodium fluoride")]
        NonEvacuatedBloodCollectionTubePotassiumOxalateSodiumFluoride = 702287009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container, boric acid (H3BO3)/sodium formate")]
        EvacuatedUrineSpecimenContainerBoricAcidSodiumFormate = 702288004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container, ethyl paraben/sodium porpionate/chlorhexidine")]
        EvacuatedUrineSpecimenContainerEthylParabenSodiumPorpionateChlorhexidine = 702289007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cervical cytology microscopy slide")]
        CervicalCytologyMicroscopySlide = 702290003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube , K3EDTA/sodium fluoride")]
        EvacuatedBloodCollectionTubeSodiumFluoride = 702292006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube, K2EDTA/aprotinin")]
        EvacuatedBloodCollectionTubeaProtinin = 702293001,

        /// <summary>
        /// 
        /// </summary>
        [Description("Syringe-blood collection tube transfer")]
        SyringeBloodCollectionTubeTransfer = 702294007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, clot activator/gel separator")]
        NonEvacuatedBloodCollectionTubeClotActivatorGelSeparator = 702295008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, sodium citrate")]
        NonEvacuatedBloodCollectionTubeSodiumCitrate = 702296009, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, clot activator")]
        NonEvacuatedBloodCollectionTubeClotActivator = 702297000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, K3EDTA")]
        NonEvacuatedBloodCollectionTubeK3EDTA = 702298005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, K2EDTA")]
        NonEvacuatedBloodCollectionTubeK2EDTA = 702299002,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube, lithium heparin/gel separator, non-sterile")]
        NonEvacuatedBloodCollectionTubeLithiumHeparinGelSeparatorNonSterile = 702300005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood collection funnel")]
        MicrocapillaryBloodCollectionFunnel = 702301009, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container, boric acid (H3BO3)")]
        EvacuatedUrineSpecimenContainerBoricAcid = 702302002, 
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container, multiple preservative")]
        EvacuatedUrineSpecimenContainerMultiplePreservative = 702303007, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood transfer tube, clot activator")]
        MicrocapillaryBloodTransferTubeClotActivator = 702304001, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood transfer tube, sodium fluoride")]
        MicrocapillaryBloodTransferTubeSodiumFluoride = 702305000, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood transfer tube, EDTA")]
        MicrocapillaryBloodTransferTubeEDTA = 702306004, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood transfer tube IVD, heparin")]
        MicrocapillaryBloodTransferTubeIVDHeparin = 702307008, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container IVD, no additive")]
        EvacuatedUrineSpecimenContainerIVDnoAdditive = 702308003, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Saliva specimen container IVD, no additive")]
        SalivaSpecimenContainerIVDnoAdditive = 702309006, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated saliva specimen container IVD, sodium azide")]
        EvacuatedSalivaSpecimenContainerIVDSodiumAzide = 702310001, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Orthopedic bone particle collector, reusable")]
        OrthopedicBoneParticleCollectorReusable = 704866005, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Hemoperfusion tubing set")]
        HemoperfusionTubingSet = 704921002, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Clinical sampling brush")]
        ClinicalSamplingBrush = 706042001, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Endotherapy cytology brush")]
        EndotherapyCytologyBrush = 706044000,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Bone particle collector")]
        BoneParticleCollector = 706045004, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Specimen receptacle")]
        SpecimenReceptacle = 706046003, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Fecal specimen container")]
        FecalSpecimenContainer = 706047007,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Blood specimen receptacle")]
        BloodSpecimenReceptacle = 706048002, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood tube")]
        BloodTube = 706049005, 

        /// <summary>
        /// 
        /// </summary>
        [Description("Microcapillary blood collection tube")]
        MicrocapillaryBloodCollectionTube = 706050005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Non-evacuated blood collection tube")]
        NonEvacuatedBloodCollectionTube = 706051009,

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated blood collection tube")]
        EvacuatedBloodCollectionTube = 706052002,

        /// <summary>
        /// 
        /// </summary>
        [Description("General specimen container")]
        GeneralSpecimenContainer = 706053007,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urine specimen container")]
        UrineSpecimenContainer = 706054001,

        /// <summary>
        /// 
        /// </summary>
        [Description("24-hour urine specimen container")]
        urineSpecimenContainer24Hour = 706055000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Evacuated urine specimen container")]
        EvacuatedUrineSpecimenContainer = 706056004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Cytology specimen container")]
        CytologySpecimenContainer = 706057008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Secretory specimen container")]
        SecretorySpecimenContainer = 706058003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood collection/transfer device")]
        BloodCollectionTransferDevice = 706067003,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood donor set")]
        BloodDonorSet = 706070004,

        /// <summary>
        /// 
        /// </summary>
        [Description("Specimen receptacle transport container")]
        SpecimenReceptacleTransportContainer = 706071000,

        /// <summary>
        /// 
        /// </summary>
        [Description("Autologous blood collection tube")]
        AutologousBloodCollectionTube = 712485008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Adipose tissue stem cell recovery unit, ultrasonic")]
        AdiposeTissueStemCellRecoveryUnitUltrasonic = 713951005,

        /// <summary>
        /// 
        /// </summary>
        [Description("Blood component separator")]
        BloodComponentSeparator = 714731008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urological fluid funnel, sterile")]
        UrologicalFluidFunnelSterile = 718301008,

        /// <summary>
        /// 
        /// </summary>
        [Description("Urological fluid funnel, non-sterile")]
        UrologicalFluidFunnelNonSterile = 718302001

    }
}
