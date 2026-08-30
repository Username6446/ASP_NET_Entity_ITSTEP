using Project01.Models;
using Microsoft.EntityFrameworkCore;

namespace Project01.Data.Initializer
{
    public static class Seeder
    {
        public static async Task SeedAsync(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await dbContext.Database.MigrateAsync();

            // Categories
            if (!await dbContext.Categories.AnyAsync())
            {
                List<Category> categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Процесори",
                        Description = "Центральні процесори для настільних ПК та серверів.",
                        Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg"
                    },
                    new Category
                    {
                        Name = "Відеокарти",
                        Description = "Графічні адаптери для ігор, роботи з графікою та штучного інтелекту.",
                        Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10"
                    },
                    new Category
                    {
                        Name = "Материнські плати",
                        Description = "Основні плати для підключення всіх компонентів комп'ютера.",
                        Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg"
                    },
                    new Category
                    {
                        Name = "Оперативна пам'ять",
                        Description = "Модулі пам'яті RAM (DDR4, DDR5) для швидкого доступу до даних.",
                        Image = "https://ipkey.com.ua/media/k2/items/cache/0afa57c41887ce47355dc00226c6156f_XL.jpg"
                    },
                    new Category
                    {
                        Name = "Накопичувачі SSD",
                        Description = "Твердотільні диски для зберігання інформації.",
                        Image = "https://hotline.ua/img/uploads/clients/5d8b721a44df5.jpg"
                    },
                    new Category
                    {
                        Name = "Накопичувачі HDD",
                        Description = "Жорсткі диски для зберігання інформації.",
                        Image = "https://artline.ua/storage/images/editor/editor_1667650143803718_0.webp"
                    },
                    new Category
                    {
                        Name = "Накопичувачі M.2",
                        Description = "Твердотільні швидкі диски для зберігання інформації.",
                        Image = "https://www.kingspec.com/uploads/image/66f0bf6010378.png"
                    },
                    new Category
                    {
                        Name = "Блоки живлення",
                        Description = "Пристрої для забезпечення стабільного живлення всіх компонентів системи.",
                        Image = "https://marketing.brain.com.ua/static/articles_icon/7394.webp"
                    },
                    new Category
                    {
                        Name = "Корпуси",
                        Description = "Корпуси для ПК різних форматів з підтримкою систем охолодження.",
                        Image = "https://s.ek.ua/posts/files/5655/wide_pic.jpg"
                    },
                    new Category
                    {
                        Name = "Монітори",
                        Description = "Екрани та дисплеї для комп'ютерів з різною частотою оновлення та роздільною здатністю.",
                        Image = "https://denika.ua/image/cache/catalog/blog/kak-vibrat_monitor-912x466.png"
                    },
                    new Category
                    {
                        Name = "Системи охолодження",
                        Description = "Повітряні кулери та системи рідинного охолодження для процесорів.",
                        Image = "https://s.ek.ua/posts/files/6033/wide_pic.jpg"
                    }
                };

                await dbContext.Categories.AddRangeAsync(categories);
                await dbContext.SaveChangesAsync();
            }

            if (!await dbContext.Products.AnyAsync())
            {
                var cpuCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == "Процесори");
                var gpuCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == "Відеокарти");
                var mbCategory = await dbContext.Categories.FirstOrDefaultAsync(c => c.Name == "Материнські плати");

                var products = new List<Product>();

                if (cpuCategory != null)
                {
                    products.AddRange(new List<Product>
                    {
                        new Product
                        {
                            Name = "Intel Core i5-13400F",
                            Price = 8200.00,
                            Description = "10-ядерний процесор (6P + 4E) з тактовою частотою до 4.6 ГГц для бюджетних ігрових збірок.",
                            Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg",
                            Amount = 15,
                            Category = cpuCategory
                        },
                        new Product
                        {
                            Name = "Intel Core i7-14700K",
                            Price = 17500.00,
                            Description = "20-ядерний процесор з розблокованим множником для ентузіастів і рендерингу.",
                            Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg",
                            Amount = 8,
                            Category = cpuCategory
                        },
                        new Product
                        {
                            Name = "AMD Ryzen 5 7600X",
                            Price = 9300.00,
                            Description = "6-ядерний процесор на архітектурі Zen 4 з підтримкою сокета AM5 та PCIe 5.0.",
                            Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg",
                            Amount = 12,
                            Category = cpuCategory
                        },
                        new Product
                        {
                            Name = "AMD Ryzen 7 7800X3D",
                            Price = 18900.00,
                            Description = "Один з найкращих ігрових процесорів із технологією 3D V-Cache.",
                            Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg",
                            Amount = 6,
                            Category = cpuCategory
                        },
                        new Product
                        {
                            Name = "AMD Ryzen 9 7950X",
                            Price = 24500.00,
                            Description = "Флагманський 16-ядерний процесор для важких обчислень та робочих станцій.",
                            Image = "https://s.ek.ua/posts/files/6001/wide_pic.jpg",
                            Amount = 4,
                            Category = cpuCategory
                        }
                    });
                }

                if (gpuCategory != null)
                {
                    products.AddRange(new List<Product>
                    {
                        new Product
                        {
                            Name = "ASUS Dual GeForce RTX 4060 EVO",
                            Price = 14500.00,
                            Description = "Компактна відеокарта на 8 ГБ GDDR6 для комфортного геймінгу у Full HD.",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10",
                            Amount = 10,
                            Category = gpuCategory
                        },
                        new Product
                        {
                            Name = "Gigabyte GeForce RTX 4070 SUPER Windforce",
                            Price = 29800.00,
                            Description = "12 ГБ GDDR6X відеопам'яті, підтримка DLSS 3.5 та трасування променів у 2K.",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10",
                            Amount = 7,
                            Category = gpuCategory
                        },
                        new Product
                        {
                            Name = "MSI GeForce RTX 4080 SUPER GAMING X SLIM",
                            Price = 48500.00,
                            Description = "Преміальна графіка на 16 ГБ GDDR6X для безкомпромісного геймінгу у 4K.",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10",
                            Amount = 3,
                            Category = gpuCategory
                        },
                        new Product
                        {
                            Name = "Sapphire Pulse Radeon RX 7600",
                            Price = 12200.00,
                            Description = "Доступне графічне рішення від AMD на архітектурі RDNA 3.",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10",
                            Amount = 9,
                            Category = gpuCategory
                        },
                        new Product
                        {
                            Name = "PowerColor Hellhound Radeon RX 7800 XT",
                            Price = 24900.00,
                            Description = "16 ГБ швидкої пам'яті для високої частоти кадрів у роздільній здатності 1440p.",
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRMrlqSfU0wP5Pq8f20kzIUBgPSo9jWYdLqNJH_SyHhrJel18he8go2tsOH&s=10",
                            Amount = 5,
                            Category = gpuCategory
                        }
                    });
                }

                if (mbCategory != null)
                {
                    products.AddRange(new List<Product>
                    {
                        new Product
                        {
                            Name = "MSI B760 GAMING PLUS WIFI",
                            Price = 6400.00,
                            Description = "Надійна плата для процесорів Intel 12-14 поколінь з підтримкою DDR5 та Wi-Fi 6E.",
                            Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg",
                            Amount = 14,
                            Category = mbCategory
                        },
                        new Product
                        {
                            Name = "ASUS ROG STRIX Z790-E GAMING WIFI II",
                            Price = 21500.00,
                            Description = "Топова материнська плата з потужною підсистемою живлення для розгону Intel Core i9.",
                            Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg",
                            Amount = 4,
                            Category = mbCategory
                        },
                        new Product
                        {
                            Name = "Gigabyte B650 AORUS ELITE AX",
                            Price = 8900.00,
                            Description = "Збалансована плата під сокет AMD AM5 з радіаторами для M.2 накопичувачів.",
                            Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg",
                            Amount = 11,
                            Category = mbCategory
                        },
                        new Product
                        {
                            Name = "ASRock B650M-HDV/M.2",
                            Price = 4900.00,
                            Description = "Бюджетний форм-фактор Micro-ATX на чипсеті AMD B650 для компактних ПК.",
                            Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg",
                            Amount = 16,
                            Category = mbCategory
                        },
                        new Product
                        {
                            Name = "MSI MAG X670E TOMAHAWK WIFI",
                            Price = 13800.00,
                            Description = "Материнська плата ентузіаст-класу з повною підтримкою шини PCIe 5.0 для сокета AM5.",
                            Image = "https://s.ek.ua/posts/files/6619/wide_pic.jpg",
                            Amount = 6,
                            Category = mbCategory
                        }
                    });
                }

                if (products.Any())
                {
                    await dbContext.Products.AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }

        }
    }
}
