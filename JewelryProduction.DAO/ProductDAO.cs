using JewelryProduction.BusinessObject.Filter;
using JewelryProduction.BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace JewelryProduction.DAO
{
    public class ProductDAO
    {
        public ProductDAO() { }

        /* public List<Product> GetProducts(FilterModel filterModel)
         {
             using (var context = new JewelryProductionContext())
             {
                 return context.Products                      
                     .Where(p => p.Status == "ACTIVE")
                     .OrderByDescending(p => p.CreateDate)
                     .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                     .Take(filterModel.PageSize)
                     .ToList();
             }
         }
        */
        // Get list product
        public List<Product> GetProducts(FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material) // Include bảng Material
                    .Include(p => p.ProductType) // Include bảng ProductType
                    .Include(p => p.Counter) // Include bảng Counter
                    .OrderByDescending(p => p.CreateDate)
                    .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                    .Take(filterModel.PageSize)
                    .ToList();
            }
        }

        //get list product for customer buy and store by type
        public List<Product> GetProductsForCustomerBuyAndStoreBuy()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material) // Include bảng Material
                    .Include(p => p.ProductType) // Include bảng ProductType
                    .Include(p => p.Counter) // Include bảng Counter
                    .Where(p => p.Status == "AVAILABLE" || p.Status == "SALED")
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();
            }
        }

        //get products by material id
        public List<Product> GetProductsByMaterialId(Guid materialId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products.Include(p => p.ProductStones)
                                        .ThenInclude(ps => ps.Stone)
                                        .Where(p => p.MaterialId == materialId)
                                        .ToList();
            }
        }

        //get product type by id
        public ProductType GetProductTypeById(Guid productTypeId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductTypes

                .FirstOrDefault(pt => pt.Id == productTypeId);
            }
        }

        //get product stones
        public List<ProductStone> GetProductStones(Guid productId)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.ProductStones
                .Where(ps => ps.ProductId == productId)
                .ToList();
            }
        }

        // get product by id
        public Product GetProductById(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType) // Include bảng ProductType
                    .Include(p => p.Counter) // Include bảng Counter
                    .FirstOrDefault(p => p.Id.Equals(id));
            }
        }

        //create
        public Product Create(Product product)
        {
            using (var context = new JewelryProductionContext())
            {
                product.Id = Guid.NewGuid();
                product.Status = "AVAILABLE";
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
        }

        //change to status
        public bool ChangeStatus(Guid id)
        {
            using (var context = new JewelryProductionContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id.Equals(id));
                if (product == null)
                {
                    return false;
                }

                product.Status = product.Status == "AVAILABLE" ? "INACTIVE" : "AVAILABLE";
                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
        }

        //update 
        public bool Update(Guid id, Product updatedProduct)
        {
            using (var context = new JewelryProductionContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id.Equals(id));
                if (product == null)
                {
                    return false;
                }

                product.Name = updatedProduct.Name;
                product.Description = updatedProduct.Description;
                product.Weight = updatedProduct.Weight;
                /*product.Material = updatedProduct.Material;*/
                product.Price = updatedProduct.Price;
                product.CreateDate = updatedProduct.CreateDate;
                product.UpdateDate = updatedProduct.UpdateDate;
                //product.Status = updatedProduct.Status;
                // Other properties...

                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
        }

        //update status
        public bool UpdateStatus(Guid id, string status)
        {
            using (var context = new JewelryProductionContext())
            {
                var product = context.Products.FirstOrDefault(p => p.Id.Equals(id));
                if (product == null)
                {
                    return false;
                }


                product.UpdateDate = DateTime.Now;
                product.Status = status;

                context.Products.Update(product);
                context.SaveChanges();
                return true;
            }
        }

        //count total item
        public int TotalItem()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products.Count();
            }
        }

        //get product by product code

        public Product GetProductByProductCode(string productCode)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                       .Where(p => p.ProductCode == productCode)
                       .Include(p => p.Material)
                       .Include(p => p.ProductType)
                       .Include(p => p.Counter)
                       .FirstOrDefault();
            }
        }

        //get product active without paging
        public List<Product> GetProductsActiveWithoutPaging()
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Where(p => p.Status == "AVAILABLE")
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .OrderByDescending(p => p.CreateDate)
                    .ToList();
            }
        }

        //search product by product type name
        public List<Product> SearchProductByProductTypeName(string product_type_name)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .Where(p => p.ProductType.Name.Contains(product_type_name))
                    .ToList();
            }
        }

        //search product by product code
        public List<Product> SearchProductByProductCode(string product_code)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .Where(p => p.ProductCode.Contains(product_code))
                    .ToList();
            }
        }

        // search product by material name
        public List<Product> SearchProductByMaterialName(string material_name)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .Where(p => p.Material.Name.Contains(material_name))
                    .ToList();
            }
        }

        //search product by counter name
        public List<Product> SearchProductByCounterName(string counter_name)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .Where(p => p.Counter.Name.Contains(counter_name))
                    .ToList();
            }
        }

        //search product by price
        public List<Product> SearchProductsByPrice(decimal priceFrom, decimal priceTo)
        {
            using (var context = new JewelryProductionContext())
            {
                return context.Products
                .Include(p => p.Material)
                .Include(p => p.ProductType)
                .Include(p => p.Counter)
                .Where(p => p.Price >= priceFrom && p.Price <= priceTo)
                .ToList();
            }
        }

        //search sort product
        public List<Product> SearchSort(string counter_name, string product_code, string product_type, string material)
        {
            using (var context = new JewelryProductionContext())
            {
                var products = context.Products
                    .Include(p => p.Material)
                    .Include(p => p.ProductType)
                    .Include(p => p.Counter)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(counter_name))
                {
                    products = products.Where(p => p.Counter.Name.Contains(counter_name));
                }

                if (!string.IsNullOrEmpty(product_code))
                {
                    products = products.Where(p => p.Name.Contains(product_code));
                }

                if (!string.IsNullOrEmpty(product_type))
                {
                    products = products.Where(p => p.ProductType.Name.Contains(product_type));
                }

                if (!string.IsNullOrEmpty(material))
                {
                    products = products.Where(p => p.Material.Name.Contains(material));
                }

                return products.OrderBy(p => p.Name).ToList();
            }
        }

        //recal product
        public Product ReCalProduct(string productCode)
        {
            using (var context = new JewelryProductionContext())
            {
                var oldProduct = GetProductByProductCode(productCode);

                var newProduct = oldProduct;
                newProduct.Price = 0; //reset value
                var productType = context.ProductTypes.FirstOrDefault(pt => pt.Id == newProduct.ProductTypeId);
                var material = context.Materials.FirstOrDefault(m => m.Id == newProduct.MaterialId);
                /*var stonePrices = context.ProductStones.Where(ps => ps.ProductId == product.Id).ToList().Sum(ps => ps.Stone.Price);*/
                var stonePrices = context.ProductStones
                                         .Where(ps => ps.ProductId == newProduct.Id)
                                         .Include(ps => ps.Stone) // Ensure Stone entity is included
                                         .ToList()
                                         .Sum(ps => ps.Stone != null && ps.Stone.StoneType == "Precious" ? ps.Stone.Price * 0.7m : 0);


                newProduct.Price = (material.BuyingPrice * (newProduct.Weight / 1000)) + productType.Wages + stonePrices;
                newProduct.UpdateDate = DateTime.Now;



                return newProduct;
            }
        }

        //search product
        public List<Product> SearchProduct(string? productCode, Guid? productTypeId, Guid? materialId, Guid? counterId, string status, FilterModel filterModel)
        {
            using (var context = new JewelryProductionContext())
            {
                var query = context.Products.Include(p => p.ProductType)
                                            .Include(p => p.Material)
                                            .Include(p => p.Counter)
                                            .AsQueryable();

                if (!string.IsNullOrEmpty(productCode))
                {
                    query = query.Where(p => p.ProductCode.Equals(productCode));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(p => p.Status.Equals(status));
                }

                if (productTypeId.HasValue)
                {
                    query = query.Where(p => p.ProductTypeId.Equals(productTypeId));
                }

                if (materialId.HasValue)
                {
                    query = query.Where(p => p.MaterialId.Equals(materialId));
                }

                if (counterId.HasValue)
                {
                    query = query.Where(p => p.CounterId.Equals(counterId));
                }

                return query.OrderByDescending(p => p.CreateDate)
                            .Skip((filterModel.PageIndex - 1) * filterModel.PageSize)
                            .Take(filterModel.PageSize)
                            .ToList();
            }
        }

    }
}


