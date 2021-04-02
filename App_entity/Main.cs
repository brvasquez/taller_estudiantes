using System;
using System.Linq;
using System.Collections.Generic;
using App_entity;
using App_entity.Modelo;

namespace APP_Entity
{
    class main
    {
        static List<Estudiantes> ListaEstudiantes = new List<Estudiantes>();
        static Validations Validar = new Validations();
        static void Main(string[] args)

        {
            int posicion;
            string temporal;
            bool EntValida = false;
            do
            {
                for (int i = 4; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 2); Console.WriteLine("▄");
                    Console.SetCursorPosition(i, 7); Console.WriteLine("▄");
                }
                for (int i = 3; i <= 7; i++)
                {
                    Console.SetCursorPosition(4, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(10, 4); Console.WriteLine("App Estudiantes");
                Console.SetCursorPosition(10, 6); Console.WriteLine("1.Agregar");
                Console.SetCursorPosition(25, 6); Console.WriteLine("2.Listar");
                Console.SetCursorPosition(38, 6); Console.WriteLine("3.Buscar");
                Console.SetCursorPosition(50, 6); Console.WriteLine("4.Editar");
                Console.SetCursorPosition(65, 6); Console.WriteLine("5.Borrar");
                Console.SetCursorPosition(79, 6); Console.WriteLine("0.Salir");

                for (int i = 4; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 10); Console.Write("▄");
                    Console.SetCursorPosition(i, 25); Console.Write("▄");
                }
                for (int i = 11; i <= 25; i++)
                {
                    Console.SetCursorPosition(4, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(38, 12); Console.WriteLine(" BIENVENIDOS");
                // Logo Sena
                Console.SetCursorPosition(10, 15); Console.Write(" ▓▓▓▓▓ ▓▓▓▓▓▓ ▓▓     ▓   ▓▓▓  ");
                Console.SetCursorPosition(10, 16); Console.Write("▓      ▓      ▓ ▓    ▓  ▓   ▓ ");
                Console.SetCursorPosition(10, 17); Console.Write("▓      ▓      ▓  ▓   ▓ ▓     ▓");
                Console.SetCursorPosition(10, 18); Console.Write(" ▓▓▓▓  ▓▓▓▓▓  ▓   ▓  ▓ ▓▓▓▓▓▓▓");
                Console.SetCursorPosition(10, 19); Console.Write("     ▓ ▓      ▓    ▓ ▓ ▓     ▓");
                Console.SetCursorPosition(10, 20); Console.Write("     ▓ ▓      ▓     ▓▓ ▓     ▓");
                Console.SetCursorPosition(10, 21); Console.Write("▓▓▓▓▓  ▓▓▓▓▓▓ ▓      ▓ ▓     ▓");
                Console.SetCursorPosition(10, 23); Console.WriteLine("Centro de Gestión de Mercados, Logística y Tecnologías de la Información");
                
                posicion = int.Parse(Console.ReadLine());  
                
                do
                {
                    Console.SetCursorPosition(74, 4); Console.WriteLine("Digite una opcion [ ]");
                    temporal = Console.ReadLine();
                    //Console.WriteLine(temporal, " soy temporal");
                    if (!Validar.Vacio(temporal))
                        if (Validar.TipoNumero(temporal))
                            EntValida = true;
                } while (!EntValida);
                switch (posicion)
                {
                    case 1: 
                        AgregarEstudiantes();
                        break;
                    case 2:
                        ListarEstudiantes();
                        break;
                    case 3:
                        BuscarEstudiantes();
                        break;
                    case 4:
                        EditarEstudiantes();
                        break;
                    case 5:
                        BorrarEstudiantes();
                        break;

                    case 0:
                        Console.Clear();

                        for (int i = 2; i < 100; i++)
                        {
                            Console.SetCursorPosition(i, 4); Console.Write("▄");
                            Console.SetCursorPosition(i, 25); Console.Write("▄");
                        }
                        for (int i = 5; i <= 25; i++)
                        {
                            Console.SetCursorPosition(2, i); Console.WriteLine("▓");
                            Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                        }

                        Console.SetCursorPosition(32, 10); Console.WriteLine(" ******************************");
                        Console.SetCursorPosition(32, 11); Console.WriteLine(" Gracias por usar el aplicativo");
                        Console.SetCursorPosition(32, 12); Console.WriteLine(" ******************************");
                        
                        
                        Console.SetCursorPosition(35, 21); Console.WriteLine("──────▄▀▄─────▄▀▄──────");
                        Console.SetCursorPosition(35, 22); Console.WriteLine("─────▄█░░▀▀▀▀▀░░█▄─────");
                        Console.SetCursorPosition(35, 23); Console.WriteLine("─▄▄──█░░░░░░░░░░░█──▄▄─");
                        Console.SetCursorPosition(35, 24); Console.WriteLine("█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█");

                        Console.ReadKey();
                        break;
                }
            } while (posicion != 0);

			static void AgregarEstudiantes()

			{
				Console.Clear();
                var db = new taller_estudiantesContext();

                string nom = "";
				string email, cod;
				bool CodigoValido = false;
				bool NombreValido = false;
				bool CorreoValido = false;

                for (int i = 5; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 6); Console.Write("▄");
                    Console.SetCursorPosition(i, 25); Console.Write("▄");
                }
                for (int i = 7; i <= 25; i++)
                {
                    Console.SetCursorPosition(5, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                do
                {
                    Console.SetCursorPosition(35, 10); Console.Write(" Digite Codigo del Estudiantes: ");
                    cod = Console.ReadLine();
                    if (!Validar.Vacio(cod))
                        if (Validar.TipoNumero(cod))
                            CodigoValido = true;
                } while (!CodigoValido);

                if (Existe(Convert.ToInt32(cod)))
                    Console.WriteLine("El codigo " + cod + " Ya existe en el sistema");
                else
                    do
                    {
                        Console.SetCursorPosition(35, 11); Console.Write(" Digite nombre del Estudiantes : ");
                        nom = Console.ReadLine();
                        if (!Validar.Vacio(nom))
                            if (Validar.TipoTexto(nom))
                                NombreValido = true;
                    } while (!NombreValido);

                do
				{

                    Console.SetCursorPosition(35, 12); Console.Write(" Digite correo del Estudiantes : ");
					email = Console.ReadLine();
					if (!Validar.Vacio(email))
						if (Validar.emailValido(email))
							CorreoValido = true;
				} while (!CorreoValido);


                Console.SetCursorPosition(36, 13); Console.Write("Digite la nota # 1  ");
				double not1 = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(36, 14); Console.Write("Digite la nota # 2 ");
				double not2 = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(36, 15); Console.Write("Digite la nota # 3 ");
				double not3 = double.Parse(Console.ReadLine());
				

				Estudiantes nuevoEstudiante = new Estudiantes();
                nuevoEstudiante.Codigo = Convert.ToInt32(cod);
                nuevoEstudiante.Nombre = nom;
                nuevoEstudiante.Correo = email;
                nuevoEstudiante.Nota1 = not1;
                nuevoEstudiante.Nota2 = not2;
                nuevoEstudiante.Nota3 = not3;

                Console.WriteLine(nuevoEstudiante.Nombre);

                db.Estudiantes.Add(nuevoEstudiante);
                db.SaveChanges();

                ListaEstudiantes.Add(nuevoEstudiante);
                Console.Clear();
            }

            static void ListarEstudiantes()
            {
                Console.Clear();
                var db = new taller_estudiantesContext();
                var estudiantes = db.Estudiantes.ToList();
                int y = 10;

                for (int i = 2; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 4); Console.Write("▄");
                    Console.SetCursorPosition(i, 35); Console.Write("▄");
                }
                for (int i = 5; i <= 35; i++)
                {
                    Console.SetCursorPosition(2, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(10, y);Console.Write("$Codigo:");
                Console.SetCursorPosition(20, y); Console.Write("Nombre:");
                Console.SetCursorPosition(40, y); Console.Write("Correo:");
                Console.SetCursorPosition(65, y); Console.Write("Nota 1:");
                Console.SetCursorPosition(75, y); Console.Write("Nota 2:");
                Console.SetCursorPosition(85, y); Console.Write("Nota 3:");
                Console.Write("\t");


                foreach (var miEstudiante in estudiantes)
                {
                    y++;
                    Console.SetCursorPosition(10, y);Console.Write(miEstudiante.Codigo);
                    Console.SetCursorPosition(20, y); Console.Write(miEstudiante.Nombre);
                    Console.SetCursorPosition(40, y); Console.Write(miEstudiante.Correo);
                    Console.SetCursorPosition(65, y); Console.Write(miEstudiante.Nota1);
                    Console.SetCursorPosition(75, y); Console.Write(miEstudiante.Nota2);
                    Console.SetCursorPosition(85, y); Console.Write(miEstudiante.Nota3);
                                                           
                }
                Console.Write("\t");

                //foreach (var miEstudiante in estudiantes)
                //{
                //    Console.WriteLine($"Codigo: [{miEstudiante.Codigo}],\t Nombre: [{miEstudiante.Nombre}],\t Correo: [{miEstudiante.Correo}],\t Nota 1: [{miEstudiante.Nota1}],\t Nota 2: [{miEstudiante.Nota2}],\t  Nota 3: [{miEstudiante.Nota3}]");
                //}

                Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗"); 
                Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
                Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");

                
                Console.ReadKey();
                Console.Clear();
            }

            static void BuscarEstudiantes()
            {
                string cod;
                var db = new taller_estudiantesContext();
                

                Console.Clear();

                for (int i = 2; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 4); Console.Write("▄");
                    Console.SetCursorPosition(i, 35); Console.Write("▄");
                }
                for (int i = 5; i <= 35; i++)
                {
                    Console.SetCursorPosition(2, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(10, 10); Console.WriteLine(" Buscar Estudiantes ");                
                Console.SetCursorPosition(10, 12); Console.Write(" Digite Codigo del Estudiantes que desea buscar: ");
                

                cod = Console.ReadLine();
                

                if (Existe(Convert.ToInt32(cod)))
                {
                    Estudiantes myEstudiantes = db.Estudiantes.Find(Convert.ToInt32(cod));
                  
                    
                    Console.SetCursorPosition(10, 15); Console.Write("codigo : " + myEstudiantes.Codigo);
                    Console.SetCursorPosition(10, 16); Console.Write("nombre : " + myEstudiantes.Nombre);
                    Console.SetCursorPosition(10, 17); Console.Write("correo : " + myEstudiantes.Correo);
                    Console.SetCursorPosition(10, 18); Console.Write("Nota 1 : " + myEstudiantes.Nota1);
                    Console.SetCursorPosition(10, 19); Console.Write("Nota 2 : " + myEstudiantes.Nota2);
                    Console.SetCursorPosition(10, 20); Console.Write("Nota 3 : " + myEstudiantes.Nota3);


                }
                else 
                {
                    Console.SetCursorPosition(10, 20); Console.WriteLine("╔═════════════════════════════════════════════╗");
                    Console.SetCursorPosition(10, 21); Console.WriteLine("║  El Usuario " + cod + " NO  existe en el sistema     ║");
                    Console.SetCursorPosition(10, 22); Console.WriteLine("╚═════════════════════════════════════════════╝");
                }

                Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
                Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey();
                Console.Clear();
            }

            static void BorrarEstudiantes()
            {
                string cod;
                var db = new taller_estudiantesContext();


                Console.Clear();

                for (int i = 2; i < 100; i++)
                {
                    Console.SetCursorPosition(i, 4); Console.Write("▄");
                    Console.SetCursorPosition(i, 35); Console.Write("▄");
                }
                for (int i = 5; i <= 35; i++)
                {
                    Console.SetCursorPosition(2, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(99, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(17, 7); Console.Write(" Digite Codigo del Estudiantes que desea eliminar : ");
                cod = Console.ReadLine();

                if (Existe(Convert.ToInt32(cod)))
                {
                    Estudiantes myEstudiantes = db.Estudiantes.Find(Convert.ToInt32(cod));
                    Console.SetCursorPosition(10, 15); Console.Write("codigo : " + myEstudiantes.Codigo);
                    Console.SetCursorPosition(10, 16); Console.Write("nombre : " + myEstudiantes.Nombre);
                    Console.SetCursorPosition(10, 17); Console.Write("correo : " + myEstudiantes.Correo);
                    Console.SetCursorPosition(10, 18); Console.Write("Nota 1 : " + myEstudiantes.Nota1);
                    Console.SetCursorPosition(10, 19); Console.Write("Nota 2 : " + myEstudiantes.Nota2);
                    Console.SetCursorPosition(10, 20); Console.Write("Nota 3 : " + myEstudiantes.Nota3);
                    Console.SetCursorPosition(10, 25); Console.Write("Esta seguro que desea eliminar el Estudiantes? S/N   :  ");
                    string flag = Console.ReadLine();
                    if (flag == "S" || flag == "s")
                    {
                        db.Estudiantes.Remove(myEstudiantes);
                        db.SaveChanges();

                        // ListaEstudiantes.Remove(myEstudiantes);
                    }
                    else if (flag == "N" || flag == "n")
                    {
                        Console.SetCursorPosition(10, 26); Console.Write("Se ha cancelado la eliminación del Estudiante, oprima una tecla para volver ");
                        Console.ReadKey();
                        //Console.Clear();
                    } else
                    {
                        Console.SetCursorPosition(4, 27); Console.Write("La opcion ingresada no es valida, oprima cualquier tecla para volver al menu principal ");
                    }

                }
                else
                {
                    Console.SetCursorPosition(20, 20); Console.WriteLine("╔═════════════════════════════════════════════╗");
                    Console.SetCursorPosition(20, 21); Console.WriteLine("║  El Usuario " + cod + " NO  existe en el sistema     ║");
                    Console.SetCursorPosition(20, 22); Console.WriteLine("╚═════════════════════════════════════════════╝");
                }
                Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
                Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                Console.ReadKey();
                Console.Clear();
            }

            static void EditarEstudiantes()
            {
                var db = new taller_estudiantesContext();

                bool NombreValido = false;
                bool CorreoValido = false;
                bool EntValida = false;

                string nom, email, cod;
                string atributoAEditar;

                Console.Clear();

                for (int i = 2; i < 108; i++)
                {
                    Console.SetCursorPosition(i, 4); Console.Write("▄");
                    Console.SetCursorPosition(i, 35); Console.Write("▄");
                }
                for (int i = 5; i <= 35; i++)
                {
                    Console.SetCursorPosition(2, i); Console.WriteLine("▓");
                    Console.SetCursorPosition(107, i); Console.WriteLine("▓");
                }

                Console.SetCursorPosition(25, 7); Console.Write(" Digite Codigo del Estudiantes que desea editar: ");
                cod = Console.ReadLine();

                if (Existe(Convert.ToInt32(cod)))
                {
                    Estudiantes myEstudiantes = db.Estudiantes.Find(Convert.ToInt32(cod));
                    Console.SetCursorPosition(5, 9); Console.WriteLine("Codigo: " + myEstudiantes.Codigo + "\t Nombre: " + myEstudiantes.Nombre + "\t Correo: " + myEstudiantes.Correo + "\t Nota 1 : " + myEstudiantes.Nota1 + "\t Nota 2 : " + myEstudiantes.Nota2 + "\t Nota 3 : " + myEstudiantes.Nota3);
                    Console.SetCursorPosition(5, 11); Console.WriteLine("Escribe el atributo a editar: ");
                    Console.SetCursorPosition(5, 12); Console.WriteLine("1. Nombre");
                    Console.SetCursorPosition(5, 13); Console.WriteLine("2. Email");
                    Console.SetCursorPosition(5, 14); Console.WriteLine("3. Nota 1");
                    Console.SetCursorPosition(5, 15); Console.WriteLine("4. Nota 2");
                    Console.SetCursorPosition(5, 16); Console.WriteLine("5. Nota 3");
                    do
                    {
                        atributoAEditar = Console.ReadLine();
                        if (!Validar.Vacio(atributoAEditar))
                            if (Validar.TipoNumero(atributoAEditar))
                                EntValida = true;
                    } while (!EntValida);

                    switch (Convert.ToInt32(atributoAEditar))
                    {
                        case 1:
                            //Console.WriteLine("Nombre a editar");
                            do
                            {
                                Console.SetCursorPosition(5, 18); Console.Write("Digite nuevo nombre del Estudiantes : ");
                                nom = Console.ReadLine();
                                if (!Validar.Vacio(nom))
                                    if (Validar.TipoTexto(nom))
                                        NombreValido = true;
                                myEstudiantes.Nombre = nom;
                            } while (!NombreValido);
                            break;
                        case 2:
                            do
                            {
                                Console.SetCursorPosition(5, 18); Console.Write("Digite nuevo correo del Estudiantes : ");
                                email = Console.ReadLine();
                                if (!Validar.Vacio(email))
                                    if (Validar.emailValido(email))
                                        CorreoValido = true;
                                myEstudiantes.Correo = email;
                            } while (!CorreoValido); 
                            break;
                        case 3:
                            Console.SetCursorPosition(5, 18); Console.WriteLine("Digite la nueva nota: ");
                            double not1 = double.Parse(Console.ReadLine());
                            myEstudiantes.Nota1 = not1;
                            break;
                        case 4:
                            Console.SetCursorPosition(5, 18); Console.WriteLine("Digite la nueva nota: ");
                            double not2 = double.Parse(Console.ReadLine());
                            myEstudiantes.Nota2 = not2;
                            break;
                        case 5:
                            Console.SetCursorPosition(5, 18); Console.WriteLine("Digite la nueva nota: ");
                            double not3 = double.Parse(Console.ReadLine());
                            myEstudiantes.Nota3 = not3;
                            break;
                    }
                    db.Estudiantes.Update(myEstudiantes);
                    db.SaveChanges();

                    Console.SetCursorPosition(10, 29); Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                    Console.SetCursorPosition(10, 30); Console.WriteLine("║ ███▓▒░░Si desea volver al menu principal, oprima cualquier tecla░░▒▓███  ║");
                    Console.SetCursorPosition(10, 31); Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            static bool Existe(int cod)
            {
                bool aux = false;
                var db = new taller_estudiantesContext();
                var estudiantes = db.Estudiantes.ToList();
                foreach (var miEstudiante in estudiantes)
                {
                    if (miEstudiante.Codigo == cod)
                        aux = true;
                }
                return aux;
            }
        }       
    }
}