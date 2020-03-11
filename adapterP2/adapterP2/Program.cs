using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace adapterP2
{
    public class Product
    {
        public string name { get; set; }
        public int price { get; set; }
        public Product( string nombre, int precio)
        {
            name = nombre;
            price = precio;
        }

        public Product()
        {
        }
    }
    public static class ProductDataProvider
    {
        public static List<Product> GetData() =>
            new List<Product>
            {
                new Product("Xiaomi Remi Note 7", 8500),
                new Product("Xiaomi Remi Note 8",12000),
                new Product("Xiaomi Remi Note 9",20000),


            };
    }
    public class XmlConverter
    {
        public XDocument GetXml()
        {
            var xDocument = new XDocument();
            var xElement = new XElement("Productos");
            var xAttributes = ProductDataProvider.GetData()
                .Select(m => new XElement("Producto",
                new XAttribute("Nombre", m.name), new XAttribute("Precio", m.price)));
            xElement.Add(xAttributes);
            xDocument.Add(xElement);
            return xDocument;
        }

    }
    public class XmlToJsonAdapter : IXmltoJson
    {
        private XmlConverter _xmlConverter;
        public XmlToJsonAdapter(XmlConverter xmlConverter)
        {
            _xmlConverter = xmlConverter;
        }

        public void ConvertXmlToJson()
        {
            var products = _xmlConverter.GetXml()
                  .Element("Productos")
                  .Elements("Producto")
                  .Select(m => new Product
                  {
                      name = m.Attribute("Nombre").Value,
                      price = int.Parse(m.Attribute("Precio").Value)
                  });
            new JsonConverter(products).ConvertToJson();
        }
    }
    public interface IXmltoJson
    {
        void ConvertXmlToJson();
    }
    public class JsonConverter
    {
        private IEnumerable<Product> _productData;

        public JsonConverter(IEnumerable<Product> productData)
        {
            _productData = productData;
        }

        public void ConvertToJson()
        {
            var result = JsonConvert.SerializeObject(_productData, Formatting.Indented);
            Console.WriteLine(result);
        }

      
    }
    class Program
    {
        static void Main(string[] args)
        {
            var xmlConverter = new XmlConverter();
            var adapter = new XmlToJsonAdapter(xmlConverter);
            adapter.ConvertXmlToJson();
            Console.ReadLine();
        }
    } 
}
