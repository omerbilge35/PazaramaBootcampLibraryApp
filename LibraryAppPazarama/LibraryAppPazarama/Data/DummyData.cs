using LibraryAppPazarama.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAppPazarama.Data
{
    public static class DummyData
    {
        public static void Dummy(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<LibraryDbContext>();
            context.Database.Migrate();

            var genres = new List<Genre>()
                        {
                            new Genre {Name="Macera", Books=
                                new List<Books>(){
                                    new Books {
                                        Title="Da Vinci Şifresi",
                                        Description="Harvard Üniversitesi Simge-Bilim Profesörü Robert Langdon, Paris'te iş gezisindeyken, gece yarısı, Louvre'un yaşlı müdürünün ölü bulunduğu haberini alır.",
                                        ImageUrl="davinci_sifresi.jpg"
                                    },
                                    new Books {
                                        Title="Başlangıç",
                                        Description="Bilim kurgu türündeki romanları ile dünyayı kasıp kavuran Dan Brown, bu defa Başlangıç isimli kitabı ile okuyucuları karşılıyor. Yazarın eserlerindeki temel konu olan din ve bilim arasındaki gelgitler, bu romanda da ön plana çıkıyor. İnsanlığın tarihini konu edinen roman, geçmiş ve gelecek ile ilgili büyük ipuçları barındırıyor.",
                                        ImageUrl="baslangic.jpg"
                                    },

                                }
                            },
                            new Genre {Name="Polisiye"},
                            new Genre {Name="Bilim Kurgu"},
                            new Genre {Name="Korku Gerilim"},
                            new Genre {Name="Romantik"},
                            new Genre {Name="Türk Klasik"}
                        };
            var book = new List<Books>()
                        {
                            new Books {
                                Title="Tepenin Laneti",
                                Description="Larchfield’ın en nüfuzlu adamı Angus Russell, Harrow Hill’deki malikânesinde boğazı kesilerek öldürülmüştür. Olay mahallindeki DNA ve parmak izleri, kurbana karşı husumeti bulunan belalı Billy Tate'e işaret eder. Ancak bir sorun vardır: Tate, bir gün önce kilisenin çatısından düşerek ölmüştür.",
                                ImageUrl="tepenin_laneti.jpg",
                                Genres = new List<Genre>() {genres[0], genres[1] }
                            },
                            new Books {
                                Title="Zaman Makinesi",
                                Description="Victoria dönemi Londra’sında yaşayan bir bilim insanı zamanda yolculuk yapmak üzere icat ettiği makineyle geleceğin İngiltere’sini ziyaret eder. Sekiz Yüz İki Bin Yedi Yüz Bir yılında yaşadığı macerayı bir dost meclisinde anlatır.",
                                ImageUrl="zaman_makinesi.jpg",
                                Genres = new List<Genre>() {genres[3] }
                            },
                            new Books {
                                Title="Hayvan Mezarlığı - Gecenin Pençesi",
                                Description="Bu eseri beyazperdeye de aktarıldı. Film, bütün dünyada yankılar yaratmaya devam ediyor.Dr. Louis Creed ve ailesi eski kızılderili mezarlığındaki ruhların gazabına uğramışlardı... Bunun elbette nedenleri olmalıydı!...STEPHEN KiNG okurlarını, doğaüstü olaylarla bezenmiş heyecanların doruğuna götürüyor.",
                                ImageUrl="hayvan_mezarligi.jpg",
                                Genres = new List<Genre>() {genres[0], genres[3] }
                            },
                                new Books {
                                Title="Köşedeki Dükkan",
                                Description="Rosa Larkin, Londra’da sıradan işinden ve amaçsız hayatından sıkılmıştır. Bir gün tanımadığı birinden deniz kıyısındaki küçük bir kasabada eski bir dükkân miras kalır. Miras bırakanın tek bir koşulu vardır: Genç kadın, dükkânı satamayacak, sadece zamanı geldiğinde hak eden birisine devredebilecektir.",
                                ImageUrl="kosedeki_dukkan.jpg",
                                Genres = new List<Genre>() {genres[4]}
                            },
                            new Books {
                                Title="Mai ve Siyah - Günümüz Türkçesiyle",
                                Description="Halid Ziya'ya kadar, romancı muhayyilesiyle doğmuş tek muharririmiz yoktur. Hepsi roman veya hikâye yazmaya hevesli insanlardır. -Ahmet Hamdi Tanpınar-",
                                ImageUrl="maivesiyah.jpg",
                                Genres = new List<Genre>() {genres[5]}
                            },
                            new Books {
                                Title="Yaban",
                                Description="Yakup Kadri Karaosmanoğlu’nun en başarılı romanları arasında gösterilen Yaban, ilk defa 1932 yılında okuyucuyla buluşuyor. Romanda zaman aralığı olarak Birinci Dünya Savaşı’ndan Sakarya Meydan Muharebesi’nin sonuna kadar geçen süre seçiliyor.",
                                ImageUrl="yaban.jpg",
                                Genres = new List<Genre>() {genres[5]}
                            }
                        };

            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }

                if(context.Books.Count()== 0)
                {
                    context.Books.AddRange(book);
                }

                context.SaveChanges();
            }

        }
    }
}
