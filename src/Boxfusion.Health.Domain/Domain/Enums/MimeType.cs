using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Identifies the type of the data in the attachment and allows a method to be chosen to interpret or render the data. 
    /// Includes mime type parameters such as charset where appropriate.
    /// </summary>
    [ReferenceList("HealthDomain", "MimeType")]
    public enum RefListMimeType : int
    {
        /// <summary>
        /// Digital Imaging and Communications in Medicine (DICOM) MIME type defined in RFC3240 \[http://ietf.org/rfc/rfc3240.txt\].
        /// </summary>
        [Description("DICOM (application/dicom)")]
        applicationDicom = 1,

        /// <summary>
        /// This format is very prone to compatibility problems. If sharing of edit-able text is required, text/plain, text/html or text/rtf should be used instead.
        /// </summary>
        [Description("MSWORD (application/msword)")]
        applicationMsword = 2,

        /// <summary>
        /// The Portable Document Format is recommended for written text that is completely laid out and read-only. PDF is a platform 
        /// independent, widely deployed, and open specification with freely available creation and rendering tools.
        /// </summary>
        [Description("PDF (application/pdf)")]
        applicationPdf = 3,

        /// <summary>
        /// This is a format for single channel audio, encoded using 8bit ISDN mu-law \[PCM\] at a sample rate of 8000 Hz. This format is 
        /// standardized by: CCITT, Fascicle III.4 -Recommendation G.711. Pulse Code Modulation (PCM) of Voice Frequencies. Geneva, 1972.
        /// </summary>
        [Description("Basic Audio (audio/basic)")]
        audioBasic = 4,

        /// <summary>
        /// ADPCM allows compressing audio data. It is defined in the Internet specification RFC 2421 \[ftp://ftp.isi.edu/in-notes/rfc2421.txt\]. 
        /// Its implementation base is unclear.
        /// </summary>
        [Description("K32ADPCM Audio (audio/k32adpcm)")]
        audioK32adpcm = 5,

        /// <summary>
        /// MPEG-1 Audio layer-3 is an audio compression algorithm and file format defined in ISO 11172-3 and ISO 13818-3. 
        /// MP3 has an adjustable sampling frequency for highly compressed telephone to CD quality audio.
        /// </summary>
        [Description("MPEG audio layer 3 (audio/mpeg)")]
        audioMpeg = 6,

        /// <summary>
        /// This is recommended only for fax applications.
        /// </summary>
        [Description("G3Fax Image (image/g3fax)")]
        imageG3fax = 7,

        /// <summary>
        /// GIF is a popular format that is universally well supported. However GIF is patent encumbered and should therefore be used with caution.
        /// </summary>
        [Description("GIF Image (image/gif)")]
        imageGif = 8,

        /// <summary>
        /// This format is required for high compression of high color photographs. It is a "lossy" compression, but the difference to lossless compression is almost unnoticeable to the human vision.
        /// </summary>
        [Description("JPEG Image (image/jpeg)")]
        imageJpeg = 9,

        /// <summary>
        /// Portable Network Graphics (PNG) \[http://www.cdrom.com/pub/png\] is a widely supported lossless image compression standard with open source code available.
        /// </summary>
        [Description("PNG Image (image/png)")]
        imagePng = 10,

        /// <summary>
        /// Although TIFF (Tag Image File Format) is an international standard it has many interoperability problems in practice. Too many different versions that 
        /// are not handled by all software alike.
        /// </summary>
        [Description("TIFF Image (image/tiff)")]
        imageTiff = 11,

        /// <summary>
        /// This is an openly standardized format for 3D models that can be useful for virtual reality applications such as anatomy or biochemical research 
        /// (visualization of the steric structure of macromolecules)
        /// </summary>
        [Description("VRML Model (model/vrml)")]
        modelVrml = 12,

        /// <summary>
        /// The HL7 clinical document Architecture, Level 1 MIME package.
        /// </summary>
        [Description("CDA Level 1 Multipart (multipart/x-hl7-cda-level-one)")]
        multipartxhl7cdalevelone = 13,

        /// <summary>
        /// The HL7 clinical document Architecture, Level 1 MIME package.
        /// </summary>
        [Description("CDA Level 1 Multipart (multipart/x-hl7-cda-level1)")]
        multipartxhl7cdalevel1 = 14,

        /// <summary>
        /// For marked-up text according to the Hypertext Mark-up Language. HTML markup is sufficient for typographically marking-up most written-text documents. 
        /// HTML is platform independent and widely deployed.
        /// </summary>
        [Description("HTML Text (text/html)")]
        textHtml = 15,

        /// <summary>
        /// **Description:**For any plain text. This is the default and is used for a character string (ST) data type.
        /// </summary>
        [Description("Plain Text (text/plain)")]
        textPlain = 16,

        /// <summary>
        /// The Rich Text Format is widely used to share word-processor documents. However, RTF does have compatibility problems, as it is quite dependent on the 
        /// word processor. May be useful if word processor edit-able text should be shared.
        /// </summary>
        [Description("RTF Text (text/rtf)")]
        textRtf = 17,

        /// <summary>
        /// For structured character based data. There is a risk that general SGML/XML is too powerful to allow a sharing of general SGML/XML documents between 
        /// different applications.
        /// </summary>
        [Description("SGML Text (text/sgml)")]
        textSgml = 18,

        /// <summary>
        /// For compatibility, this represents the HL7 v2.x FT data type. Its use is recommended only for backward compatibility with HL7 v2.x systems.
        /// </summary>
        [Description("HL7 Text (text/x-hl7-ft)")]
        textxhl7ft = 19,

        /// <summary>
        /// **Description:** The content described by the CDA Narrative Block (not just used by CDA).
        /// </summary>
        [Description("HL7 Structured Narrative (text/x-hl7-text+xml)")]
        textxhl7textxml = 20,

        /// <summary>
        /// For structured character based data. There is a risk that general SGML/XML is too powerful to allow a sharing of general SGML/XML documents between 
        /// different applications.
        /// </summary>
        [Description("XML Text (text/xml)")]
        textxml = 21,

        /// <summary>
        /// MPEG is an international standard, widely deployed, highly efficient for high color video; open source code exists; highly interoperable.
        /// </summary>
        [Description("MPEG Video (video/mpeg)")]
        videoMpeg = 22,

        /// <summary>
        /// The AVI file format is just a wrapper for many different codecs; it is a source of many interoperability problems.
        /// </summary>
        [Description("X-AVI Video ( video/x-avi)")]
        videoxavi = 23
    }
}
