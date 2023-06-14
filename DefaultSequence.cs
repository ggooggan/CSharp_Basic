using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OptionTestProject
{
    public class DefaultSequence
    {
        [JsonPropertyName("ADDNEWSAMPLE")]
        public ADDNEWSAMPLE addNewSample { get; set; }

        [JsonPropertyName("PUNCH")]
        public PUNCH punch { get; set; }

        [JsonPropertyName("HEATING")]
        public HEATING heating { get; set; }

        [JsonPropertyName("DISPENSING")]
        public DISPENSING dispensing { get; set; }

        [JsonPropertyName("IMAGE")]
        public IMAGE image { get; set; }

        public static async void SaveChanged(DefaultSequence defaultSequenceSettings)
        {
            using FileStream stream = new FileStream("default.json", FileMode.Create);
            using StreamWriter writer = new StreamWriter(stream);
            await writer.WriteAsync(JsonSerializer.Serialize(defaultSequenceSettings));
        }
    }

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ADDNEWSAMPLE
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("addnewsampleCheck")]
        public AddnewsampleCheck addnewsampleCheck { get; set; }

        [JsonPropertyName("cartridgeBarcode")]
        public CartridgeBarcode cartridgeBarcode { get; set; }

        [JsonPropertyName("gpCheck")]
        public GpCheck gpCheck { get; set; }

        [JsonPropertyName("gnCheck")]
        public GnCheck gnCheck { get; set; }

        [JsonPropertyName("mainSlot")]
        public MainSlot mainSlot { get; set; }

        [JsonPropertyName("panelBarcode")]
        public PanelBarcode panelBarcode { get; set; }

        [JsonPropertyName("panelSlot")]
        public PanelSlot panelSlot { get; set; }

        [JsonPropertyName("panelVer")]
        public PanelVer panelVer { get; set; }

        [JsonPropertyName("qcCheck")]
        public QcCheck qcCheck { get; set; }

        [JsonPropertyName("sampleBarcode")]
        public SampleBarcode sampleBarcode { get; set; }

        [JsonPropertyName("sampleSlot")]
        public SampleSlot sampleSlot { get; set; }
    }

    public class AddnewsampleCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ADPNormalSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgardispensingCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarDispensingPutRatio
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarDispensingSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarDispensingSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarDispensingZ
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionCulture
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionDispensingSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionDispensingSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionVol
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarEmissionZ
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarGetVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarGetWaitTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarMixGetVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarMixNum
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarMixPutVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarPutVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarSampleMixNum
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarSampleMixVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AgarSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class AirGapVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothdispensingCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothDispensingSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothDispensingSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothDispensingZ
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothEmissionVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothEmissionZ
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothGetVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothPutVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class BrothSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class CartridgeBarcode
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ContainerWaitTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ContainerZ
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class DefaultSquence
    {
        [JsonPropertyName("ADDNEWSAMPLE")]
        public ADDNEWSAMPLE ADDNEWSAMPLE { get; set; }

        [JsonPropertyName("PUNCH")]
        public PUNCH PUNCH { get; set; }

        [JsonPropertyName("HEATING")]
        public HEATING HEATING { get; set; }

        [JsonPropertyName("DISPENSING")]
        public DISPENSING DISPENSING { get; set; }

        [JsonPropertyName("IMAGE")]
        public IMAGE IMAGE { get; set; }
    }

    public class DispensePerPulse
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class DISPENSING
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("ADP_NormalSpeed")]
        public ADPNormalSpeed ADP_NormalSpeed { get; set; }

        [JsonPropertyName("Agar_Dispensing_Put_Ratio")]
        public AgarDispensingPutRatio Agar_Dispensing_Put_Ratio { get; set; }

        [JsonPropertyName("Agar_Dispensing_Z")]
        public AgarDispensingZ Agar_Dispensing_Z { get; set; }

        [JsonPropertyName("Agar_Emission_Culture")]
        public AgarEmissionCulture Agar_Emission_Culture { get; set; }

        [JsonPropertyName("Agar_Emission_Vol")]
        public AgarEmissionVol Agar_Emission_Vol { get; set; }

        [JsonPropertyName("Agar_Emission_Z")]
        public AgarEmissionZ Agar_Emission_Z { get; set; }

        [JsonPropertyName("Agar_EmissionSpeed")]
        public AgarEmissionSpeed Agar_EmissionSpeed { get; set; }

        [JsonPropertyName("agardispensingCheck")]
        public AgardispensingCheck agardispensingCheck { get; set; }

        [JsonPropertyName("AgarDispensingSylingeGetSpeed")]
        public AgarDispensingSylingeGetSpeed AgarDispensingSylingeGetSpeed { get; set; }

        [JsonPropertyName("AgarDispensingSylingePutSpeed")]
        public AgarDispensingSylingePutSpeed AgarDispensingSylingePutSpeed { get; set; }

        [JsonPropertyName("AgarEmissionDispensingSylingeGetSpeed")]
        public AgarEmissionDispensingSylingeGetSpeed AgarEmissionDispensingSylingeGetSpeed { get; set; }

        [JsonPropertyName("AgarEmissionDispensingSylingePutSpeed")]
        public AgarEmissionDispensingSylingePutSpeed AgarEmissionDispensingSylingePutSpeed { get; set; }

        [JsonPropertyName("AgarGet_Vol")]
        public AgarGetVol AgarGet_Vol { get; set; }

        [JsonPropertyName("AgarGetWait_Time")]
        public AgarGetWaitTime AgarGetWait_Time { get; set; }

        [JsonPropertyName("AgarMix_Num")]
        public AgarMixNum AgarMix_Num { get; set; }

        [JsonPropertyName("AgarMixGet_Vol")]
        public AgarMixGetVol AgarMixGet_Vol { get; set; }

        [JsonPropertyName("AgarMixPut_Vol")]
        public AgarMixPutVol AgarMixPut_Vol { get; set; }

        [JsonPropertyName("AgarPut_Vol")]
        public AgarPutVol AgarPut_Vol { get; set; }

        [JsonPropertyName("AgarSampleMix_Num")]
        public AgarSampleMixNum AgarSampleMix_Num { get; set; }

        [JsonPropertyName("AgarSampleMix_Vol")]
        public AgarSampleMixVol AgarSampleMix_Vol { get; set; }

        [JsonPropertyName("AgarSylingeGetSpeed")]
        public AgarSylingeGetSpeed AgarSylingeGetSpeed { get; set; }

        [JsonPropertyName("AgarSylingePutSpeed")]
        public AgarSylingePutSpeed AgarSylingePutSpeed { get; set; }

        [JsonPropertyName("AirGap_Vol")]
        public AirGapVol AirGap_Vol { get; set; }

        [JsonPropertyName("Broth_Dispensing_Z")]
        public BrothDispensingZ Broth_Dispensing_Z { get; set; }

        [JsonPropertyName("Broth_Emission_Vol")]
        public BrothEmissionVol Broth_Emission_Vol { get; set; }

        [JsonPropertyName("Broth_Emission_Z")]
        public BrothEmissionZ Broth_Emission_Z { get; set; }

        [JsonPropertyName("brothdispensingCheck")]
        public BrothdispensingCheck brothdispensingCheck { get; set; }

        [JsonPropertyName("BrothDispensingSylingeGetSpeed")]
        public BrothDispensingSylingeGetSpeed BrothDispensingSylingeGetSpeed { get; set; }

        [JsonPropertyName("BrothDispensingSylingePutSpeed")]
        public BrothDispensingSylingePutSpeed BrothDispensingSylingePutSpeed { get; set; }

        [JsonPropertyName("BrothGet_Vol")]
        public BrothGetVol BrothGet_Vol { get; set; }

        [JsonPropertyName("BrothPut_Vol")]
        public BrothPutVol BrothPut_Vol { get; set; }

        [JsonPropertyName("BrothSylingeGetSpeed")]
        public BrothSylingeGetSpeed BrothSylingeGetSpeed { get; set; }

        [JsonPropertyName("BrothSylingePutSpeed")]
        public BrothSylingePutSpeed BrothSylingePutSpeed { get; set; }

        [JsonPropertyName("Container_Z")]
        public ContainerZ Container_Z { get; set; }

        [JsonPropertyName("ContainerWait_Time")]
        public ContainerWaitTime ContainerWait_Time { get; set; }

        [JsonPropertyName("Dispense_per_pulse")]
        public DispensePerPulse Dispense_per_pulse { get; set; }

        [JsonPropertyName("dispensingCheck")]
        public DispensingCheck dispensingCheck { get; set; }

        [JsonPropertyName("DispensingWait_Time")]
        public DispensingWaitTime DispensingWait_Time { get; set; }

        [JsonPropertyName("Emission_Check")]
        public EmissionCheck Emission_Check { get; set; }

        [JsonPropertyName("InitialEmission_Vol")]
        public InitialEmissionVol InitialEmission_Vol { get; set; }

        [JsonPropertyName("Panel_DispensingSpeed")]
        public PanelDispensingSpeed Panel_DispensingSpeed { get; set; }

        [JsonPropertyName("PostCooling")]
        public PostCooling PostCooling { get; set; }

        [JsonPropertyName("PostCooling_Time")]
        public PostCoolingTime PostCooling_Time { get; set; }

        [JsonPropertyName("PreCooling_Time")]
        public PreCoolingTime PreCooling_Time { get; set; }

        [JsonPropertyName("SampleAgarSylingeGetSpeed")]
        public SampleAgarSylingeGetSpeed SampleAgarSylingeGetSpeed { get; set; }

        [JsonPropertyName("SampleAgarSylingePutSpeed")]
        public SampleAgarSylingePutSpeed SampleAgarSylingePutSpeed { get; set; }

        [JsonPropertyName("SampleLoad_Bias_Vol")]
        public SampleLoadBiasVol SampleLoad_Bias_Vol { get; set; }

        [JsonPropertyName("SampleLoadGN_Vol")]
        public SampleLoadGNVol SampleLoadGN_Vol { get; set; }

        [JsonPropertyName("SampleLoadGN_Vol_QC")]
        public SampleLoadGNVolQC SampleLoadGN_Vol_QC { get; set; }

        [JsonPropertyName("SampleLoadGP_Vol")]
        public SampleLoadGPVol SampleLoadGP_Vol { get; set; }

        [JsonPropertyName("SampleLoadGP_Vol_QC")]
        public SampleLoadGPVolQC SampleLoadGP_Vol_QC { get; set; }

        [JsonPropertyName("SampleShake_Num")]
        public SampleShakeNum SampleShake_Num { get; set; }

        [JsonPropertyName("SampleShake_Vol")]
        public SampleShakeVol SampleShake_Vol { get; set; }

        [JsonPropertyName("SampleShake_Zup")]
        public SampleShakeZup SampleShake_Zup { get; set; }

        [JsonPropertyName("SampleShakeWait_Time")]
        public SampleShakeWaitTime SampleShakeWait_Time { get; set; }

        [JsonPropertyName("SampleSylingeGetSpeed")]
        public SampleSylingeGetSpeed SampleSylingeGetSpeed { get; set; }

        [JsonPropertyName("SampleSylingePutSpeed")]
        public SampleSylingePutSpeed SampleSylingePutSpeed { get; set; }

        [JsonPropertyName("Syringe_Speed_Get")]
        public SyringeSpeedGet Syringe_Speed_Get { get; set; }

        [JsonPropertyName("Syringe_Speed_Put")]
        public SyringeSpeedPut Syringe_Speed_Put { get; set; }

        [JsonPropertyName("TipAlign")]
        public TipAlign TipAlign { get; set; }
    }

    public class DispensingCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class DispensingWaitTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class EmissionCheck
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class FocusMarkDown
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class FocusMarkUp
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ForceImageCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class GnCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class GpCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class HeatCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class HEATING
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("heatCheck")]
        public HeatCheck heatCheck { get; set; }

        [JsonPropertyName("high")]
        public High high { get; set; }

        [JsonPropertyName("high_standard")]
        public HighStandard high_standard { get; set; }

        [JsonPropertyName("highWaitTime")]
        public HighWaitTime highWaitTime { get; set; }

        [JsonPropertyName("low")]
        public Low low { get; set; }

        [JsonPropertyName("low_standard")]
        public LowStandard low_standard { get; set; }

        [JsonPropertyName("stableTime")]
        public StableTime stableTime { get; set; }

        [JsonPropertyName("stay")]
        public Stay stay { get; set; }
    }

    public class High
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class HighStandard
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class HighWaitTime
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class IMAGE
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("focusMark_down")]
        public FocusMarkDown focusMark_down { get; set; }

        [JsonPropertyName("focusMark_up")]
        public FocusMarkUp focusMark_up { get; set; }

        [JsonPropertyName("force_imageCheck")]
        public ForceImageCheck force_imageCheck { get; set; }

        [JsonPropertyName("Image_Save")]
        public ImageSave Image_Save { get; set; }

        [JsonPropertyName("imageCheck")]
        public ImageCheck imageCheck { get; set; }

        [JsonPropertyName("Lock")]
        public Lock Lock { get; set; }

        [JsonPropertyName("Module")]
        public Module Module { get; set; }

        [JsonPropertyName("Num_ImagePos")]
        public NumImagePos Num_ImagePos { get; set; }

        [JsonPropertyName("Num_ImagingRound")]
        public NumImagingRound Num_ImagingRound { get; set; }

        [JsonPropertyName("Num_ImagingRound_QC")]
        public NumImagingRoundQC Num_ImagingRound_QC { get; set; }

        [JsonPropertyName("Num_ReportingRound_GN")]
        public NumReportingRoundGN Num_ReportingRound_GN { get; set; }

        [JsonPropertyName("Num_ReportingRound_GN_QC")]
        public NumReportingRoundGNQC Num_ReportingRound_GN_QC { get; set; }

        [JsonPropertyName("Num_ReportingRound_GP")]
        public NumReportingRoundGP Num_ReportingRound_GP { get; set; }

        [JsonPropertyName("Num_ReportingRound_GP_QC")]
        public NumReportingRoundGPQC Num_ReportingRound_GP_QC { get; set; }

        [JsonPropertyName("OPLEDA")]
        public OPLEDA OPLEDA { get; set; }

        [JsonPropertyName("OPLEDB")]
        public OPLEDB OPLEDB { get; set; }

        [JsonPropertyName("Optic1_Exposure")]
        public Optic1Exposure Optic1_Exposure { get; set; }

        [JsonPropertyName("Optic1_Gain")]
        public Optic1Gain Optic1_Gain { get; set; }

        [JsonPropertyName("Optic1_GrayTarget")]
        public Optic1GrayTarget Optic1_GrayTarget { get; set; }

        [JsonPropertyName("Optic1_matchTH")]
        public Optic1MatchTH Optic1_matchTH { get; set; }

        [JsonPropertyName("Optic2_Exposure")]
        public Optic2Exposure Optic2_Exposure { get; set; }

        [JsonPropertyName("Optic2_Gain")]
        public Optic2Gain Optic2_Gain { get; set; }

        [JsonPropertyName("Optic2_GrayTarget")]
        public Optic2GrayTarget Optic2_GrayTarget { get; set; }

        [JsonPropertyName("Optic2_matchTH")]
        public Optic2MatchTH Optic2_matchTH { get; set; }

        [JsonPropertyName("PORT1")]
        public PORT1 PORT1 { get; set; }

        [JsonPropertyName("PORT2")]
        public PORT2 PORT2 { get; set; }

        [JsonPropertyName("Report_Check")]
        public ReportCheck Report_Check { get; set; }

        [JsonPropertyName("Save_Focus")]
        public SaveFocus Save_Focus { get; set; }

        [JsonPropertyName("Save_FocusMark")]
        public SaveFocusMark Save_FocusMark { get; set; }

        [JsonPropertyName("Stage_FocusMarkPos")]
        public StageFocusMarkPos Stage_FocusMarkPos { get; set; }

        [JsonPropertyName("Stage_FocusSpeedMax")]
        public StageFocusSpeedMax Stage_FocusSpeedMax { get; set; }

        [JsonPropertyName("Stage_FocusSpeedMin")]
        public StageFocusSpeedMin Stage_FocusSpeedMin { get; set; }

        [JsonPropertyName("Stage_FocusZdownSpeed")]
        public StageFocusZdownSpeed Stage_FocusZdownSpeed { get; set; }

        [JsonPropertyName("Stage_FocusZupSpeed")]
        public StageFocusZupSpeed Stage_FocusZupSpeed { get; set; }

        [JsonPropertyName("Stage_ImagePos1")]
        public StageImagePos1 Stage_ImagePos1 { get; set; }

        [JsonPropertyName("Stage_ImagePos2")]
        public StageImagePos2 Stage_ImagePos2 { get; set; }

        [JsonPropertyName("Stage_ImagePos3")]
        public StageImagePos3 Stage_ImagePos3 { get; set; }

        [JsonPropertyName("Stage_ImagePos4")]
        public StageImagePos4 Stage_ImagePos4 { get; set; }

        [JsonPropertyName("Stage_ImagePos5")]
        public StageImagePos5 Stage_ImagePos5 { get; set; }

        [JsonPropertyName("Stage_ImagePos6")]
        public StageImagePos6 Stage_ImagePos6 { get; set; }

        [JsonPropertyName("Stage_Speed")]
        public StageSpeed Stage_Speed { get; set; }

        [JsonPropertyName("Stage_ZstackMax")]
        public StageZstackMax Stage_ZstackMax { get; set; }

        [JsonPropertyName("Stage_ZstackStep")]
        public StageZstackStep Stage_ZstackStep { get; set; }

        [JsonPropertyName("Time_ImagingInterval")]
        public TimeImagingInterval Time_ImagingInterval { get; set; }

        [JsonPropertyName("Well_Diff")]
        public WellDiff Well_Diff { get; set; }
    }

    public class ImageCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ImageSave
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class InitialEmissionVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Lock
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Low
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class LowStandard
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class MainSlot
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Module
    {
        [JsonPropertyName("value")]
        public string value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumImagePos
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumImagingRound
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumImagingRoundQC
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumReportingRoundGN
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumReportingRoundGNQC
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumReportingRoundGP
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class NumReportingRoundGPQC
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class OPLEDA
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class OPLEDB
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic1Exposure
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic1Gain
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic1GrayTarget
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic1MatchTH
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic2Exposure
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic2Gain
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic2GrayTarget
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Optic2MatchTH
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PanelBarcode
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PanelDispensingSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PanelSlot
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PanelVer
    {
        [JsonPropertyName("value")]
        public string value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PORT1
    {
        [JsonPropertyName("value")]
        public string value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PORT2
    {
        [JsonPropertyName("value")]
        public string value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PostCooling
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PostCoolingTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PreCoolingTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class PUNCH
    {
        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("punchCheck")]
        public PunchCheck punchCheck { get; set; }
    }

    public class PunchCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class QcCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class ReportCheck
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("defaultSquence")]
        public DefaultSquence defaultSquence { get; set; }
    }

    public class SampleAgarSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleAgarSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleBarcode
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleLoadBiasVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleLoadGNVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleLoadGNVolQC
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleLoadGPVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleLoadGPVolQC
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleShakeNum
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleShakeVol
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleShakeWaitTime
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleShakeZup
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleSlot
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleSylingeGetSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SampleSylingePutSpeed
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SaveFocus
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SaveFocusMark
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StableTime
    {
        [JsonPropertyName("value")]
        public List<int> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageFocusMarkPos
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageFocusSpeedMax
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageFocusSpeedMin
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageFocusZdownSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageFocusZupSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos1
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos2
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos3
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos4
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos5
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageImagePos6
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageSpeed
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageZstackMax
    {
        [JsonPropertyName("value")]
        public double value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class StageZstackStep
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class Stay
    {
        [JsonPropertyName("value")]
        public List<double> value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SyringeSpeedGet
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class SyringeSpeedPut
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class TimeImagingInterval
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class TipAlign
    {
        [JsonPropertyName("value")]
        public bool value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }

    public class WellDiff
    {
        [JsonPropertyName("value")]
        public int value { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }
    }


}
