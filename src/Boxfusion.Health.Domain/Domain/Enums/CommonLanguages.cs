using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// The human language of the content. The value can be any valid value according to BCP 47.
    /// </summary>
    [ReferenceList("HealthDomain", "CommonLanguage")]
    public enum RefListCommonLanguage : int
    {
        /// <summary>
        /// Arabic
        /// </summary>
        [Description("Arabic")]
        ar = 1,

        /// <summary>
        /// Bengali
        /// </summary>
        [Description("Bengali")]
        bn = 2,

        /// <summary>
        /// Czech
        /// </summary>
        [Description("Czech")]
        cs = 3,

        /// <summary>
        /// Danish
        /// </summary>
        [Description("Danish")]
        da = 4,

        /// <summary>
        /// German
        /// </summary>
        [Description("German")]
        de = 5,

        /// <summary>
        /// German (Austria)
        /// </summary>
        [Description("German (Austria)")]
        deAT = 6,

        /// <summary>
        /// German (Switzerland)
        /// </summary>
        [Description("German (Switzerland)")]
        deCH = 7,

        /// <summary>
        /// German (Germany)
        /// </summary>
        [Description("German (Germany)")]
        deDE = 8,

        /// <summary>
        /// Greek
        /// </summary>
        [Description("Greek")]
        el = 9,

        /// <summary>
        /// English
        /// </summary>
        [Description("English")]
        en = 10,

        /// <summary>
        /// English
        /// </summary>
        [Description("English (Australia)")]
        enAU = 11,

        /// <summary>
        /// English (Great Britain)
        /// </summary>
        [Description("English (Great Britain)")]
        enGB = 12,

        /// <summary>
        /// English (India)
        /// </summary>
        [Description("English (India)")]
        enIN = 13,

        /// <summary>
        /// English (New Zeland)
        /// </summary>
        [Description("English (New Zeland)")]
        enNZ = 14,

        /// <summary>
        /// English (Singapore)
        /// </summary>
        [Description("English (Singapore)")]
        enSG = 15,

        /// <summary>
        /// English (United States)
        /// </summary>
        [Description("English (United States)")]
        enUS = 16,

        /// <summary>
        /// Spanish
        /// </summary>
        [Description("Spanish")]
        es = 17,

        /// <summary>
        /// Spanish (Argentina)
        /// </summary>
        [Description("Spanish (Argentina)")]
        esAR = 18,

        /// <summary>
        /// Spanish (Spain)
        /// </summary>
        [Description("Spanish (Spain)")]
        esES = 20,

        /// <summary>
        /// Spanish (Uruguay)
        /// </summary>
        [Description("Spanish (Uruguay)")]
        esUY = 21,

        /// <summary>
        /// Finnish
        /// </summary>
        [Description("Finnish")]
        fi = 22,

        /// <summary>
        /// French
        /// </summary>
        [Description("French")]
        fr = 23,

        /// <summary>
        /// French (Belgium)
        /// </summary>
        [Description("French (Belgium)")]
        frBE = 24,

        /// <summary>
        /// French (Switzerland)
        /// </summary>
        [Description("French (Switzerland)")]
        frCH = 25,

        /// <summary>
        /// French (France)
        /// </summary>
        [Description("French (France)")]
        frFR = 26,

        /// <summary>
        /// Frysian
        /// </summary>
        [Description("Frysian")]
        fy = 27,

        /// <summary>
        /// Hindi
        /// </summary>
        [Description("Hindi")]
        hi = 28,

        /// <summary>
        /// Croatian
        /// </summary>
        [Description("Croatian")]
        hr = 29,

        /// <summary>
        /// Italian
        /// </summary>
        [Description("Italian")]
        it = 30,

        /// <summary>
        /// Italian (Switzerland)
        /// </summary>
        [Description("Italian (Switzerland)")]
        itCH = 31,

        /// <summary>
        /// Italian (Italy)
        /// </summary>
        [Description("Italian (Italy)")]
        itIT = 32,

        /// <summary>
        /// Japanese
        /// </summary>
        [Description("Japanese")]
        ja = 33,

        /// <summary>
        /// Korean
        /// </summary>
        [Description("Korean")]
        ko = 34,

        /// <summary>
        /// Dutch
        /// </summary>
        [Description("Dutch")]
        nl = 35,

        /// <summary>
        /// Dutch (Belgium)
        /// </summary>
        [Description("Dutch (Belgium)")]
        nlBE = 36,

        /// <summary>
        /// Dutch (Netherlands)
        /// </summary>
        [Description("Dutch (Netherlands)")]
        nlNL = 37,

        /// <summary>
        /// Norwegian
        /// </summary>
        [Description("Norwegian")]
        no = 38,

        /// <summary>
        /// Norwegian (Norway)
        /// </summary>
        [Description("Norwegian (Norway)")]
        noNO = 39,

        /// <summary>
        /// Punjabi
        /// </summary>
        [Description("Punjabi")]
        pa = 40,

        /// <summary>
        /// Polish
        /// </summary>
        [Description("Polish")]
        pl = 41,

        /// <summary>
        /// Portuguese
        /// </summary>
        [Description("Portuguese")]
        pt = 42,

        /// <summary>
        /// Portuguese (Brazil)
        /// </summary>
        [Description("Portuguese (Brazil)")]
        ptBR = 43,

        /// <summary>
        /// Russian
        /// </summary>
        [Description("Russian")]
        ru = 44,

        /// <summary>
        /// Russian (Russia)
        /// </summary>
        [Description("Russian (Russia)")]
        ruRU = 45,

        /// <summary>
        /// Serbian
        /// </summary>
        [Description("Serbian")]
        sr = 46,

        /// <summary>
        /// Serbian (Serbia)
        /// </summary>
        [Description("Serbian (Serbia)")]
        srRS = 47,

        /// <summary>
        /// Swedish
        /// </summary>
        [Description("Swedish")]
        sv = 48,

        /// <summary>
        /// Swedish (Sweden)
        /// </summary>
        [Description("Swedish (Sweden)")]
        svSE = 49,

        /// <summary>
        /// Telegu
        /// </summary>
        [Description("Telegu")]
        te = 50,

        /// <summary>
        /// Chinese
        /// </summary>
        [Description("Chinese")]
        zh = 51,

        /// <summary>
        /// Chinese (China)
        /// </summary>
        [Description("Chinese (China)")]
        zhCN = 52,

        /// <summary>
        /// Chinese (Hong Kong)
        /// </summary>
        [Description("Chinese (Hong Kong)")]
        zhHK = 53,

        /// <summary>
        /// 	Chinese (Singapore)
        /// </summary>
        [Description("Chinese (Singapore)")]
        zhSG = 54,

        /// <summary>
        /// Chinese (Taiwan)
        /// </summary>
        [Description("Chinese (Taiwan)")]
        zhTW = 55
    }
}
