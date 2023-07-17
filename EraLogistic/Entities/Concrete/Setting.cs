using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Setting : EntityBase, IEntity
    {
        public string HeaderLogo { get; set; }
        public string FooterLogo { get; set; }
        public string AboutUsYellowTitle { get; set; }
        public string AboutUsWhiteTitle { get; set; }
        public string AboutUsDescription { get; set; }
        public string VideoYellowTitle { get; set; }
        public string VideoWhiteTitle { get; set; }
        public string VideoLittleDescription { get; set; }
        public string VideoDescription { get; set; }
        public string VideoLink { get; set; }
        public string OurServiceYellowTitle { get; set; }
        public string OurServiceWhiteTitle { get; set; }
        public string OurServiceDescription { get; set; }
        public string OurPackageYellowTitle { get; set; }
        public string OurPackageWhiteTitle { get; set; }
        public string OurPackageDescription { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string WhatsApp { get; set; }
        public string Youtube { get; set; }
        public string GoogleMapsLocation { get; set; }

    }
}
