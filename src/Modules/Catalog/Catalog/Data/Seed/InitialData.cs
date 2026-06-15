namespace Catalog.Data.Seed;

internal class InitialData
{
    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(
                new Guid("8a8f8f52-18c3-4b89-a0b1-0212b4976321"),
                "Gaming Mouse",
                149.90m,
                "High precision wireless gaming mouse with ergonomic design",
                "gaming-mouse.png",
                ["electronics", "accessories", "gaming"]
            ),

            Product.Create( 
                new Guid("1f6e65f0-8574-4d6a-a3e1-d09d9b7c12a4"),
                "Mechanical Keyboard",
                399.90m,
                "RGB mechanical keyboard with blue switches and aluminum body",
                "mechanical-keyboard.png",
                ["electronics", "accessories", "keyboard"]
            ),

            Product.Create(
                new Guid("af9c6de5-82d2-4d3a-8235-61c5dc6fb118"),
                "Office Chair",
                899.00m,
                "Comfortable ergonomic office chair with lumbar support",
                "office-chair.png",
                ["furniture", "office"]
            ),

            Product.Create(
                new Guid("3d2d31f7-ef47-4f3e-9304-83d25e5a3286"),
                "Running Shoes",
                259.99m,
                "Lightweight running shoes designed for daily training",
                "running-shoes.png",
                ["sports", "footwear"]
            ),

            Product.Create(
                new Guid("d4886c2a-8bdc-42d2-83de-4e7a3f50e8d9"),
                "Coffee Maker",
                349.50m,
                "Automatic coffee maker with programmable timer and glass jar",
                "coffee-maker.png",
                ["home", "kitchen", "appliances"]
            ),

            Product.Create(
                new Guid("6ec2c2d6-f233-4c0a-9ff6-682da9b8d1ff"),
                "Backpack",
                189.90m,
                "Water-resistant backpack with padded laptop compartment",
                "backpack.png",
                ["bags", "travel", "accessories"]
            ),

            Product.Create(
                new Guid("cb9bca64-61c8-4a31-b314-8cd0c7cf3bb9"),
                "Smart Watch",
                799.99m,
                "Smart watch with heart rate monitor and sleep tracking",
                "smart-watch.png",
                ["electronics", "wearables"]
            ),

            Product.Create(
                new Guid("96dfb7cc-95cb-4f91-8147-68ddf3053aa1"),
                "Desk Lamp",
                129.90m,
                "LED desk lamp with adjustable brightness and flexible arm",
                "desk-lamp.png",
                ["home", "office", "lighting"]
            )
        };
}
