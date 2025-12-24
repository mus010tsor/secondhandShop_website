using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProje.Data;
using WebProje.Entities;


namespace WebProje.Controllers
{
    public class ProductsController : Controller
    {
        


        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ProductsController(ApplicationDbContext context,
                          UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }


        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(products);
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {         
            ModelState.Remove(nameof(Product.SellerId));
            ModelState.Remove(nameof(Product.Seller)); 

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(product);
            }

            var user = await _userManager.GetUserAsync(User);

            product.SellerId = user!.Id;
            product.CreatedAt = DateTime.Now;
            product.IsSold = false;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(int id)
        {
            var product = await _context.Products
                .Include(p => p.Seller)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null || product.IsSold)
                return NotFound();

            var buyerId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);
            // !!
            if (buyerId == product.SellerId)
                return BadRequest(); 

            
            var purchase = new Purchase
            {
                ProductId = product.Id,
                BuyerId = buyerId!,
                PurchasedAt = DateTime.UtcNow,
                PriceAtPurchase = product.Price
            };

            // !!
            product.IsSold = true;

            
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}
