using EticaretDemo.Models;

namespace EticaretDemo.Dtos
{
    public class HomeDto
    {
        public List<Sepet> Sepetim { get; set; }
        public List<Urun> Urunlerim { get; set; }
    }
}
