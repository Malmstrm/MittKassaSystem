using MittKassaSystem.ProductFolder;
using MittKassaSystem.ReceiptFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ShoppingFolder
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> cart { get; set; } = new List<ShoppingCartItem>();
        private List<Product> availableProducts;
        private ProductManager productManager;
        private ReceiptRepository receiptRepository;
        private readonly ReceiptNumberGenerator numberGenerator;
        private readonly ProductDisplay display;
        private readonly ReceiptDisplay receiptDisplay;

        public ShoppingCart(ProductManager productManager, ReceiptRepository receiptRepository, ReceiptDisplay receiptDisplay, ReceiptNumberGenerator numberGenerator, List<Product> availableProducts)
        {
            this.productManager = productManager;
            this.receiptRepository = receiptRepository;
            this.receiptDisplay = receiptDisplay;
            this.numberGenerator = numberGenerator;
            this.availableProducts = availableProducts; // Se till att det är List<Product>
            this.display = new ProductDisplay();
        }
        //private void UpdateAvailableProducts()
        //{
        //    //availableProducts = productManager.GetProducts();

        //    availableProducts = productManager.GetProducts();
        //    Console.WriteLine("Updated product list in ShoppingCart:");
        //    foreach (var product in availableProducts)
        //    {
        //        Console.WriteLine($"{product.Id}: {product.Name} - {product.Price:C}");
        //    }
        //}
        public void AddToCart(Product product, byte quantity)
        {
            cart.Add(new ShoppingCartItem(product, quantity));
        }

        public void AddToCartProcess()
        {
            
            while (true)
            {
                //UpdateAvailableProducts();

                Console.Clear();

                display.DisplayAllProducts(availableProducts);
                DisplayCart();

                Console.WriteLine("\nEnter the product ID and quantity (e.g., '1 3'), or type 'exit' to return to the main menu:");
                string line = Console.ReadLine();

                if (line.ToLower() == "exit")
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey(true);
                    break;
                }
                if (line.ToLower() == "pay")
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to procced to checkout.");
                    Console.ReadKey(true);
                    CompletePurchase();
                    break;
                }
                // Dela upp inmatningen i produkt-ID och kvantitet
                var parts = line.Split(' ');

                // Kontrollera att inmatningen innehåller två delar och att dessa kan tolkas som byte
                if (parts.Length == 2 && byte.TryParse(parts[0], out byte id) && byte.TryParse(parts[1], out byte quantity))
                {
                    // Leta efter produkten med angivet ID i tillgängliga produkter
                    Product selectedProduct = availableProducts.Find(p => p.Id == id);
                    if (selectedProduct != null)
                    {
                        // Kontrollera om produkten redan finns i kundvagnen
                        var existingItem = cart.FirstOrDefault(item => item.Product.Id == id);

                        if (existingItem != null)
                        {
                            // Om produkten redan finns, öka kvantiteten
                            existingItem.Quantity += quantity;
                            Console.WriteLine($"Increased quantity of {selectedProduct.Name} to {existingItem.Quantity}.");
                        }
                        else
                        {
                            // Om produkten inte finns, lägg till den i kundvagnen
                            cart.Add(new ShoppingCartItem(selectedProduct, quantity));
                            Console.WriteLine($"{quantity} of {selectedProduct.Name} added to your cart.");
                        }

                        // Visa uppdaterad kundvagn
                        DisplayCart();

                    }
                    else
                    {
                        Console.WriteLine("Product not found. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter in the format 'ID Quantity'.");
                }
            }
        }
        public decimal GetCartTotal()
        {
            return cart.Sum(x => x.TotalPrice());
        }
        public void DisplayCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("\nNo items in the cart.");
            }
            else
            {
                Console.WriteLine($"\nYour shopping cart:");
                foreach (var item in cart)
                {
                    item.DisplayCart();
                }
                Console.WriteLine($"Total amount: {GetCartTotal():C}");
            }
        }
        public void CompletePurchase()
        {
            decimal totalAmount = GetCartTotal();
            Console.Clear();
            Console.WriteLine($"Your total amount is {totalAmount:C}");
            Console.Write("Enter the amount paid: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amountPaid))
            {
                if (amountPaid >= totalAmount)
                {
                    PaymentProcessor paymentProcessor = new PaymentProcessor();
                    if (paymentProcessor.ProcessPayment(totalAmount, amountPaid))
                    {
                        // Process the purchase
                        List<Product> purchasedProducts = cart.Select(item => item.Product).ToList();

                        byte receiptNumber = numberGenerator.GetNextReceiptNumber();

                        Receipt receipt = new Receipt(receiptNumber, purchasedProducts, totalAmount, amountPaid);

                        receiptRepository.SaveReceipt(receipt);

                        Console.WriteLine($"Purchase complete! Your receipt has been saved.");

                        receiptDisplay.DisplayReceipt(receipt);

                        cart.Clear();
                        Console.WriteLine("Your cart has been cleared for the next purchase.");
                    }


                }
                else Console.WriteLine("Insufficient amount paid, please try again");
            }
            Console.WriteLine("Invalid input, please enter valid amount.");

            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey(true);
        }
    }
}
