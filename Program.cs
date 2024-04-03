using System;
using System.Collections.Generic;

namespace Quiz2_LuisCamacho
{
    internal class Program
    {

        private static int anio;

        class Evento
        {
            public DateTime Fecha { get; set; }
            public string Nombre { get; set; }


        }

        private static List<Evento> listaEventos = new List<Evento>();

        private static List<DateTime> feriados2024 = new List<DateTime>
        {
             new DateTime(2024,1,1), //año nuevo
             new DateTime (2024,3,28),//jueves santo
             new DateTime(2024,3,29),//viernes santo
             new DateTime(2024,4,11),//batalla de rivas
             new DateTime(2024,5,1),//dia del trabajador
             new DateTime(2024,6,25),//Anexion de guanacaste
             new DateTime(2024,8,2),//virgend e los angeles
             new DateTime(2024,8,15),//dia de la madre
             new DateTime(2024,8,31),//dia de la persona negra
             new DateTime(2024,9,15),//independencia
             new DateTime(2024,12,1),//abolicion del ejercito
             new DateTime(2024,12,25),//navidad
             

        };
        
        static DateTime PrimerFechaSemana(int anio, int numSemana)
        {
            DateTime ene1 = new DateTime(anio, 1, 1);
            DateTime primerDiaAnual = ene1.AddDays(-((int)ene1.DayOfWeek - 1));
            int agregarDias = (numSemana - 1) * 7;
            return primerDiaAnual.AddDays(agregarDias);
        }

       
        static void VerCalendarioPorAnio()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el año para ver el calendario (ejemplo : 2024):");
           
            if (int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine($"Calendario para el año {anio}");
                for (int mes = 1; mes <= 12; mes++)
                {
                    DateTime primerDiaDelMes = new DateTime(anio, mes, 1);
                    Console.WriteLine(primerDiaDelMes.ToString("\n MMMM yyyy"));
                    Console.WriteLine( " L  K  M  J  V  S  D");
                    int numeroDiaSemana = (int)primerDiaDelMes.DayOfWeek;
                    if (numeroDiaSemana == 0) numeroDiaSemana = 7;
                    Console.WriteLine(new string(' ', 3 * (numeroDiaSemana - 1)));
                    for (int dia = 1; dia <= DateTime.DaysInMonth(anio, mes); dia++)
                    {
                        Console.Write(dia.ToString().PadLeft(2) + " ");
                        if ((dia + numeroDiaSemana - 1) % 7 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Año no valido. ");

            }
            Console.ReadLine();

        }


        static void VerCalendarioPorMes()
        {
            Console.Clear();

            Console.WriteLine("Ingrese el año para ver el calendario: ");

            if (int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("Ingrese el numero de mes (1 -12) para ver le calendario: ");

                if (int.TryParse(Console.ReadLine(), out int mes) && mes >= 1 && mes <= 12)
                {
                    DateTime primerDiaDelMes = new DateTime(anio, mes, 1);

                    Console.WriteLine(primerDiaDelMes.ToString("MMMM yyyy"));
                    Console.WriteLine(" L  K  M  J  V  S  D");

                    int numeroDiaSemana = (int)primerDiaDelMes.DayOfWeek;

                    if (numeroDiaSemana == 0) numeroDiaSemana = 7;

                    Console.Write(new string(' ', 3 * (numeroDiaSemana - 1)));

                    for (int dia = 1; dia <= DateTime.DaysInMonth(anio, mes); dia++)
                    {
                        Console.Write(dia.ToString().PadLeft(2) + " ");

                        if ((dia + numeroDiaSemana - 1) % 7 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Numero de mes no valido. ");
                }
            }
            else
            {
                Console.WriteLine("Año no valido. ");

            }
            Console.ReadLine();

        }

        static void VerCalendarioPorSemana()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el año para ver el calendario por semana (ejemplo :2024): ");
            if (int.TryParse(Console.ReadLine(), out int anio))
            {
                Console.WriteLine("Ingrese la semana del año para ver el calendario (1-52): ");

                int numeroSemana;
                if (int.TryParse(Console.ReadLine(), out numeroSemana) && numeroSemana >= 1 && numeroSemana <= 52)
                {
                    DateTime starDate = PrimerFechaSemana(anio, numeroSemana); 
                    Console.WriteLine($"Calendario de la semana {numeroSemana} del año {anio} :");
                    for (int dia = 0; dia < 7; dia++)
                    {
                        Console.WriteLine(starDate.AddDays(dia).ToString("dddd, dd/MM/yyyy"));
                    }
                }
                else
                {
                    Console.WriteLine("Numero de semana no valido: ");
                }

            }
            else
            {
                Console.WriteLine("Año no valido. ");
            }
            Console.ReadLine();
        }

        static void ContarDiasHabilesEntreFechas()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la fecha de inicio (yyyy-MM-dd): ");
            DateTime fechaInicio;
            if (DateTime.TryParse(Console.ReadLine(), out fechaInicio))
            {
                Console.WriteLine("Ingrese la fecha de fin (yyyy-MM-dd) : ");
                DateTime fechaFin;

                if (!DateTime.TryParse(Console.ReadLine(), out fechaFin))
                {
                    Console.WriteLine("Fecha de fin no valida. ");
                }
                else
                {
                    int diasHabiles = ContarDiasHabiles(fechaInicio, fechaFin, feriados2024);

                    Console.WriteLine($"Dias habiles entre las fechas: {diasHabiles}");

                }
            }
            else
            {
                Console.WriteLine("Fecha de inicio no valida: ");
            }
            Console.ReadLine();


        }

        static void ContarDiasFeriadosDelAnio()
        {
            Console.Clear();
            Console.WriteLine($"Numero de dias feriados en 2024 : {feriados2024.Count}");

           Console.ReadLine();

        }

        static void AgendarEvento()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la fecha del evento (yyyy-MM-dd) : ");
            DateTime fechaEvento;
            if (DateTime.TryParse(Console.ReadLine(), out fechaEvento))
            {
                Console.WriteLine("Ingrese la descripcion del evento: ");
                string nombreEvento = Console.ReadLine();
                Evento evento = new Evento
                {
                    Fecha = fechaEvento,
                    Nombre = nombreEvento
                };
                listaEventos.Add(evento);
                Console.WriteLine("Evento agendado con exito. ");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Fecha del evento no valida. ");
                Console.ReadLine();
            }

        }



        static void VerEventosAgendados()
        {
            Console.Clear();

            if (listaEventos.Count == 0)
            {
                Console.WriteLine("No se han guardado eventos. ");
            }
            else
            {
                Console.WriteLine("Eventos agendados :");

                foreach (var evento in listaEventos)
                {
                    Console.WriteLine($"{evento.Fecha.ToString("yyyy-MM-dd")} - {evento.Nombre}");
                }
            }
            Console.ReadLine();

        }

        static int ContarDiasHabiles(DateTime fechaInicio, DateTime fechaFin, List<DateTime> feriados2024)
        {
            int diasHabiles = 0;
            DateTime fechaActual = fechaInicio;
            while (fechaActual <= fechaFin)
            {
                if (fechaActual.DayOfWeek != DayOfWeek.Sunday && !feriados2024.Contains(fechaActual))

                {
                    diasHabiles++;
                }
                fechaActual = fechaActual.AddDays(1);

            }
            return diasHabiles;

        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Selecione una opcion: ");
                Console.WriteLine("1. Ver calendario por año: ");
                Console.WriteLine("2. Ver calendario por mes : ");
                Console.WriteLine("3. Ver calendario por semana : ");
                Console.WriteLine("4. Contar dias habiles entre dos fechas : ");
                Console.WriteLine("5. Contar dias feriados del año : ");
                Console.WriteLine("6. Agendar un evento : ");
                Console.WriteLine("7. Ver eventos agendados : ");
                Console.WriteLine("8. Salir");

                int opcion;

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            VerCalendarioPorAnio();
                            break;
                        case 2:
                            VerCalendarioPorMes();
                            break;
                        case 3:
                            VerCalendarioPorSemana();
                            break;
                        case 4:
                            ContarDiasHabilesEntreFechas();
                            break;
                        case 5:
                            ContarDiasFeriadosDelAnio();
                            break;
                        case 6:
                            AgendarEvento();
                            break;
                        case 7:
                            VerEventosAgendados();
                            break;
                        case 8:
                            Console.WriteLine("Gracias por usar el programa, presione enter para salir. ");
                            Console.ReadLine();
                            return;

                        default:
                            Console.WriteLine("Opcion no valida, por favor selecione una opcion valida. ");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion no valida. Por favor, selecione una opcion valida. ");
                }


            }


        }
    }
}
