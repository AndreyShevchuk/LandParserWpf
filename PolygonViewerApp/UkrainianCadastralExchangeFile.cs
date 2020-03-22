using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PolygonViewerApp
{
    [XmlRoot(ElementName = "FileID")]
    public class FileID
    {
        [XmlElement(ElementName = "FileDate")]
        public string FileDate { get; set; }
        [XmlElement(ElementName = "FileGUID")]
        public string FileGUID { get; set; }
    }

    [XmlRoot(ElementName = "ServiceInfo")]
    public class ServiceInfo
    {
        [XmlElement(ElementName = "FileID")]
        public FileID FileID { get; set; }
        [XmlElement(ElementName = "FormatVersion")]
        public string FormatVersion { get; set; }
        [XmlElement(ElementName = "ReceiverName")]
        public string ReceiverName { get; set; }
        [XmlElement(ElementName = "Software")]
        public string Software { get; set; }
        [XmlElement(ElementName = "SoftwareVersion")]
        public string SoftwareVersion { get; set; }
    }

    [XmlRoot(ElementName = "License")]
    public class License
    {
        [XmlElement(ElementName = "LicenseSeries")]
        public string LicenseSeries { get; set; }
        [XmlElement(ElementName = "LicenseNumber")]
        public string LicenseNumber { get; set; }
        [XmlElement(ElementName = "LicenseIssuedDate")]
        public string LicenseIssuedDate { get; set; }
    }

    [XmlRoot(ElementName = "ChiefName")]
    public class ChiefName
    {
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
    }

    [XmlRoot(ElementName = "Chief")]
    public class Chief
    {
        [XmlElement(ElementName = "ChiefName")]
        public ChiefName ChiefName { get; set; }
        [XmlElement(ElementName = "ChiefPosition")]
        public string ChiefPosition { get; set; }
    }

    [XmlRoot(ElementName = "ExecutorName")]
    public class ExecutorName
    {
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
    }

    [XmlRoot(ElementName = "ContactInfo")]
    public class ContactInfo
    {
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
    }

    [XmlRoot(ElementName = "Executor")]
    public class Executor
    {
        [XmlElement(ElementName = "ExecutorName")]
        public ExecutorName ExecutorName { get; set; }
        [XmlElement(ElementName = "ExecutorPosition")]
        public string ExecutorPosition { get; set; }
        [XmlElement(ElementName = "ContactInfo")]
        public ContactInfo ContactInfo { get; set; }
    }

    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlElement(ElementName = "Country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "ZIP")]
        public string ZIP { get; set; }
        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "District")]
        public string District { get; set; }
        [XmlElement(ElementName = "Settlement")]
        public string Settlement { get; set; }
        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "Building")]
        public string Building { get; set; }
    }

    [XmlRoot(ElementName = "InfoLandWork")]
    public class InfoLandWork
    {
        [XmlElement(ElementName = "Executor")]
        public Executor Executor { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalPart")]
    public class AdditionalPart
    {
        [XmlElement(ElementName = "ServiceInfo")]
        public ServiceInfo ServiceInfo { get; set; }
        [XmlElement(ElementName = "InfoLandWork")]
        public InfoLandWork InfoLandWork { get; set; }
    }

    [XmlRoot(ElementName = "CoordinateSystem")]
    public class CoordinateSystem
    {
        [XmlElement(ElementName = "Local")]
        public string Local { get; set; }
    }

    [XmlRoot(ElementName = "HeightSystem")]
    public class HeightSystem
    {
        [XmlElement(ElementName = "Baltic")]
        public string Baltic { get; set; }
    }

    [XmlRoot(ElementName = "MeasurementUnit")]
    public class MeasurementUnit
    {
        [XmlElement(ElementName = "M")]
        public string M { get; set; }
    }

    [XmlRoot(ElementName = "DeterminationMethod")]
    public class DeterminationMethod
    {
        [XmlElement(ElementName = "Survey")]
        public string Survey { get; set; }
        [XmlElement(ElementName = "ExhangeFileCoordinates")]
        public string ExhangeFileCoordinates { get; set; }
    }

    [XmlRoot(ElementName = "Point")]
    public class Point
    {
        [XmlElement(ElementName = "UIDP")]
        public string UIDP { get; set; }
        [XmlElement(ElementName = "DeterminationMethod")]
        public DeterminationMethod DeterminationMethod { get; set; }
        [XmlElement(ElementName = "PN")]
        public string PN { get; set; }
        [XmlElement(ElementName = "X")]
        public Double X { get; set; }
        [XmlElement(ElementName = "Y")]
        public Double Y { get; set; }
        [XmlElement(ElementName = "MX")]
        public Double MX { get; set; }
        [XmlElement(ElementName = "MY")]
        public Double MY { get; set; }
    }

    [XmlRoot(ElementName = "PointInfo")]
    public class PointInfo
    {
        [XmlElement(ElementName = "Point")]
        public List<Point> Point { get; set; }
    }

    [XmlRoot(ElementName = "Points")]
    public class Points
    {
        [XmlElement(ElementName = "P")]
        public List<string> P { get; set; }
    }

    [XmlRoot(ElementName = "PL")]
    public class PL
    {
        [XmlElement(ElementName = "ULID")]
        public string ULID { get; set; }
        [XmlElement(ElementName = "Points")]
        public Points Points { get; set; }
        [XmlElement(ElementName = "Length")]
        public string Length { get; set; }
    }

    [XmlRoot(ElementName = "Polyline")]
    public class Polyline
    {
        [XmlElement(ElementName = "PL")]
        public List<PL> PL { get; set; }
    }

    [XmlRoot(ElementName = "ControlPoint")]
    public class ControlPoint
    {
        [XmlElement(ElementName = "P")]
        public List<string> P { get; set; }
    }

    [XmlRoot(ElementName = "MetricInfo")]
    public class MetricInfo
    {
        [XmlElement(ElementName = "CoordinateSystem")]
        public CoordinateSystem CoordinateSystem { get; set; }
        [XmlElement(ElementName = "HeightSystem")]
        public HeightSystem HeightSystem { get; set; }
        [XmlElement(ElementName = "MeasurementUnit")]
        public MeasurementUnit MeasurementUnit { get; set; }
        [XmlElement(ElementName = "PointInfo")]
        public PointInfo PointInfo { get; set; }
        [XmlElement(ElementName = "Polyline")]
        public Polyline Polyline { get; set; }
        [XmlElement(ElementName = "ControlPoint")]
        public ControlPoint ControlPoint { get; set; }
        [XmlElement(ElementName = "Area")]
        public Area Area { get; set; }
        [XmlElement(ElementName = "Perimeter")]
        public string Perimeter { get; set; }
        [XmlElement(ElementName = "Error")]
        public string Error { get; set; }
        [XmlElement(ElementName = "Externals")]
        public Externals Externals { get; set; }
    }

    [XmlRoot(ElementName = "LocalAuthorityHead")]
    public class LocalAuthorityHead
    {
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
    }

    [XmlRoot(ElementName = "DKZRHead")]
    public class DKZRHead
    {
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
    }

    [XmlRoot(ElementName = "RegionalContacts")]
    public class RegionalContacts
    {
        [XmlElement(ElementName = "LocalAuthorityHead")]
        public LocalAuthorityHead LocalAuthorityHead { get; set; }
        [XmlElement(ElementName = "DKZRHead")]
        public DKZRHead DKZRHead { get; set; }
    }

    [XmlRoot(ElementName = "ParcelLocation")]
    public class ParcelLocation
    {
        [XmlElement(ElementName = "Urban")]
        public string Urban { get; set; }
    }

    [XmlRoot(ElementName = "ParcelAddress")]
    public class ParcelAddress
    {
        [XmlElement(ElementName = "StreetType")]
        public string StreetType { get; set; }
        [XmlElement(ElementName = "StreetName")]
        public string StreetName { get; set; }
        [XmlElement(ElementName = "Building")]
        public string Building { get; set; }
    }

    [XmlRoot(ElementName = "ParcelLocationInfo")]
    public class ParcelLocationInfo
    {
        [XmlElement(ElementName = "Region")]
        public string Region { get; set; }
        [XmlElement(ElementName = "Settlement")]
        public string Settlement { get; set; }
        [XmlElement(ElementName = "District")]
        public string District { get; set; }
        [XmlElement(ElementName = "ParcelLocation")]
        public ParcelLocation ParcelLocation { get; set; }
        [XmlElement(ElementName = "ParcelAddress")]
        public ParcelAddress ParcelAddress { get; set; }
    }

    [XmlRoot(ElementName = "CategoryPurposeInfo")]
    public class CategoryPurposeInfo
    {
        [XmlElement(ElementName = "Category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "Purpose")]
        public string Purpose { get; set; }
        [XmlElement(ElementName = "Use")]
        public string Use { get; set; }
    }

    [XmlRoot(ElementName = "OwnershipInfo")]
    public class OwnershipInfo
    {
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }
    }

    [XmlRoot(ElementName = "Area")]
    public class Area
    {
        [XmlElement(ElementName = "MeasurementUnit")]
        public string MeasurementUnit { get; set; }
        [XmlElement(ElementName = "Size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "DeterminationMethod")]
        public DeterminationMethod DeterminationMethod { get; set; }
    }

    [XmlRoot(ElementName = "Line")]
    public class Line
    {
        [XmlElement(ElementName = "ULID")]
        public string ULID { get; set; }
        [XmlElement(ElementName = "FP")]
        public string FP { get; set; }
        [XmlElement(ElementName = "TP")]
        public string TP { get; set; }
    }

    [XmlRoot(ElementName = "Lines")]
    public class Lines
    {
        [XmlElement(ElementName = "Line")]
        public List<Line> Line { get; set; }
    }

    [XmlRoot(ElementName = "Boundary")]
    public class Boundary
    {
        [XmlElement(ElementName = "Lines")]
        public Lines Lines { get; set; }
        [XmlElement(ElementName = "Closed")]
        public string Closed { get; set; }
    }

    [XmlRoot(ElementName = "Externals")]
    public class Externals
    {
        [XmlElement(ElementName = "Boundary")]
        public Boundary Boundary { get; set; }
    }

    [XmlRoot(ElementName = "ParcelMetricInfo")]
    public class ParcelMetricInfo
    {
        [XmlElement(ElementName = "ParcelID")]
        public string ParcelID { get; set; }
        [XmlElement(ElementName = "Area")]
        public Area Area { get; set; }
        [XmlElement(ElementName = "Error")]
        public string Error { get; set; }
        [XmlElement(ElementName = "Externals")]
        public Externals Externals { get; set; }
    }

    [XmlRoot(ElementName = "FullName")]
    public class FullName
    {
        [XmlElement(ElementName = "LastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "FirstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "MiddleName")]
        public string MiddleName { get; set; }
    }

    [XmlRoot(ElementName = "Passport")]
    public class Passport
    {
        [XmlElement(ElementName = "DocumentType")]
        public string DocumentType { get; set; }
        [XmlElement(ElementName = "PassportNumber")]
        public string PassportNumber { get; set; }
        [XmlElement(ElementName = "PassportIssuedDate")]
        public string PassportIssuedDate { get; set; }
        [XmlElement(ElementName = "IssuanceAuthority")]
        public string IssuanceAuthority { get; set; }
        [XmlElement(ElementName = "PassportSeries")]
        public string PassportSeries { get; set; }
    }

    [XmlRoot(ElementName = "NaturalPerson")]
    public class NaturalPerson
    {
        [XmlElement(ElementName = "FullName")]
        public FullName FullName { get; set; }
        [XmlElement(ElementName = "TaxNumber")]
        public string TaxNumber { get; set; }
        [XmlElement(ElementName = "Passport")]
        public Passport Passport { get; set; }
        [XmlElement(ElementName = "Citizenship")]
        public string Citizenship { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "Authentication")]
    public class Authentication
    {
        [XmlElement(ElementName = "NaturalPerson")]
        public NaturalPerson NaturalPerson { get; set; }
    }

    [XmlRoot(ElementName = "PropertyAcquisitionJustification")]
    public class PropertyAcquisitionJustification
    {
        [XmlElement(ElementName = "Document")]
        public string Document { get; set; }
        [XmlElement(ElementName = "DocumentDate")]
        public string DocumentDate { get; set; }
        [XmlElement(ElementName = "DocumentNumber")]
        public string DocumentNumber { get; set; }
        [XmlElement(ElementName = "ApprovalAuthority")]
        public string ApprovalAuthority { get; set; }
    }

    [XmlRoot(ElementName = "ProprietorInfo")]
    public class ProprietorInfo
    {
        [XmlElement(ElementName = "Authentication")]
        public Authentication Authentication { get; set; }
        [XmlElement(ElementName = "ProprietorCode")]
        public string ProprietorCode { get; set; }
        [XmlElement(ElementName = "PropertyAcquisitionJustification")]
        public PropertyAcquisitionJustification PropertyAcquisitionJustification { get; set; }
    }

    [XmlRoot(ElementName = "Proprietors")]
    public class Proprietors
    {
        [XmlElement(ElementName = "ProprietorInfo")]
        public ProprietorInfo ProprietorInfo { get; set; }
    }

    [XmlRoot(ElementName = "TechnicalDocumentationInfo")]
    public class TechnicalDocumentationInfo
    {
        [XmlElement(ElementName = "DocumentationType")]
        public string DocumentationType { get; set; }
        [XmlElement(ElementName = "DraftingDate")]
        public string DraftingDate { get; set; }
        [XmlElement(ElementName = "DocumentList")]
        public List<string> DocumentList { get; set; }
    }

    [XmlRoot(ElementName = "LandParcelInfo")]
    public class LandParcelInfo
    {
        [XmlElement(ElementName = "CadastralCode")]
        public string CadastralCode { get; set; }
        [XmlElement(ElementName = "LandCode")]
        public string LandCode { get; set; }
        [XmlElement(ElementName = "MetricInfo")]
        public MetricInfo MetricInfo { get; set; }
    }

    [XmlRoot(ElementName = "LandsParcel")]
    public class LandsParcel
    {
        [XmlElement(ElementName = "LandParcelInfo")]
        public List<LandParcelInfo> LandParcelInfo { get; set; }
    }

    [XmlRoot(ElementName = "AdjacentBoundary")]
    public class AdjacentBoundary
    {
        [XmlElement(ElementName = "Lines")]
        public Lines Lines { get; set; }
        [XmlElement(ElementName = "Closed")]
        public string Closed { get; set; }
    }

    [XmlRoot(ElementName = "Proprietor")]
    public class Proprietor
    {
        [XmlElement(ElementName = "NaturalPerson")]
        public NaturalPerson NaturalPerson { get; set; }
        [XmlElement(ElementName = "LegalEntity")]
        public LegalEntity LegalEntity { get; set; }
    }

    [XmlRoot(ElementName = "AdditionalInfoBlock")]
    public class AdditionalInfoBlock
    {
        [XmlElement(ElementName = "AdditionalInfo")]
        public string AdditionalInfo { get; set; }
    }

    [XmlRoot(ElementName = "AdjacentUnitInfo")]
    public class AdjacentUnitInfo
    {
        [XmlElement(ElementName = "AdjacentBoundary")]
        public AdjacentBoundary AdjacentBoundary { get; set; }
        [XmlElement(ElementName = "Proprietor")]
        public Proprietor Proprietor { get; set; }
        [XmlElement(ElementName = "AdditionalInfoBlock")]
        public AdditionalInfoBlock AdditionalInfoBlock { get; set; }
    }

    [XmlRoot(ElementName = "LegalEntity")]
    public class LegalEntity
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "EDRPOU")]
        public string EDRPOU { get; set; }
        [XmlElement(ElementName = "Address")]
        public Address Address { get; set; }
    }

    [XmlRoot(ElementName = "AdjacentUnits")]
    public class AdjacentUnits
    {
        [XmlElement(ElementName = "AdjacentUnitInfo")]
        public List<AdjacentUnitInfo> AdjacentUnitInfo { get; set; }
    }

    [XmlRoot(ElementName = "ParcelInfo")]
    public class ParcelInfo
    {
        [XmlElement(ElementName = "ParcelLocationInfo")]
        public ParcelLocationInfo ParcelLocationInfo { get; set; }
        [XmlElement(ElementName = "CategoryPurposeInfo")]
        public CategoryPurposeInfo CategoryPurposeInfo { get; set; }
        [XmlElement(ElementName = "OwnershipInfo")]
        public OwnershipInfo OwnershipInfo { get; set; }
        [XmlElement(ElementName = "ParcelMetricInfo")]
        public ParcelMetricInfo ParcelMetricInfo { get; set; }
        [XmlElement(ElementName = "Proprietors")]
        public Proprietors Proprietors { get; set; }
        [XmlElement(ElementName = "TechnicalDocumentationInfo")]
        public TechnicalDocumentationInfo TechnicalDocumentationInfo { get; set; }
        [XmlElement(ElementName = "LandsParcel")]
        public LandsParcel LandsParcel { get; set; }
        [XmlElement(ElementName = "AdjacentUnits")]
        public AdjacentUnits AdjacentUnits { get; set; }
    }

    [XmlRoot(ElementName = "Parcels")]
    public class Parcels
    {
        [XmlElement(ElementName = "ParcelInfo")]
        public List <ParcelInfo> ParcelInfo { get; set; }
    }

    [XmlRoot(ElementName = "CadastralQuarterInfo")]
    public class CadastralQuarterInfo
    {
        [XmlElement(ElementName = "CadastralQuarterNumber")]
        public string CadastralQuarterNumber { get; set; }
        [XmlElement(ElementName = "RegionalContacts")]
        public RegionalContacts RegionalContacts { get; set; }
        [XmlElement(ElementName = "Parcels")]
        public Parcels Parcels { get; set; }
    }

    [XmlRoot(ElementName = "CadastralQuarters")]
    public class CadastralQuarters
    {
        [XmlElement(ElementName = "CadastralQuarterInfo")]
        public CadastralQuarterInfo CadastralQuarterInfo { get; set; }
    }

    [XmlRoot(ElementName = "CadastralZoneInfo")]
    public class CadastralZoneInfo
    {
        [XmlElement(ElementName = "KOATUU")]
        public string KOATUU { get; set; }
        [XmlElement(ElementName = "CadastralZoneNumber")]
        public string CadastralZoneNumber { get; set; }
        [XmlElement(ElementName = "CadastralQuarters")]
        public CadastralQuarters CadastralQuarters { get; set; }
    }

    [XmlRoot(ElementName = "InfoPart")]
    public class InfoPart
    {
        [XmlElement(ElementName = "MetricInfo")]
        public MetricInfo MetricInfo { get; set; }
        [XmlElement(ElementName = "CadastralZoneInfo")]
        public CadastralZoneInfo CadastralZoneInfo { get; set; }
    }

    [XmlRoot(ElementName = "UkrainianCadastralExchangeFile")]
    public class UkrainianCadastralExchangeFile
    {
        [XmlElement(ElementName = "AdditionalPart")]
        public AdditionalPart AdditionalPart { get; set; }
        [XmlElement(ElementName = "InfoPart")]
        public InfoPart InfoPart { get; set; }
    }
}
