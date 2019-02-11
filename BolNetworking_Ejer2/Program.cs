using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BolNetworking_Ejer2
{
    class Program
    {
        List<string> users = new List<string>();
        List<StreamWriter> clients = new List<StreamWriter>();
        static void Main(string[] args)
        {
            bool validPort = false;
            int puerto;
            while (!validPort)
                try
                {
                    Console.WriteLine("Introduce the port");
                    puerto = Convert.ToInt32(Console.ReadLine());
                    Program p = new Program();
                    IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    validPort = true;
                    s.Bind(ie);
                    s.Listen(10);
                    Console.WriteLine("Waiting clients");
                    while (true)
                    {
                        Socket client = s.Accept();
                        Thread thread = new Thread(() => p.HiloCliente(client));
                        thread.Start();
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid port");
                }
            Console.ReadLine();
        }

        private void HiloCliente(Socket cliente)
        {
            bool exit = false;
            string name = "";
            string message;
            try
            {
                IPEndPoint ieCliente = (IPEndPoint)cliente.RemoteEndPoint;
                Console.WriteLine("Client {0} conected in the port {1}",
                ieCliente.Address, ieCliente.Port);
                NetworkStream ns = new NetworkStream(cliente);
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                string welcome = "Welcome to the chatroom, introduce your name to continue";
                sw.WriteLine(welcome);
                sw.Flush();
                name = sr.ReadLine() + "@" + ieCliente.Address;
                sw.WriteLine("Your name will be: " + name);
                sw.Flush();
                clients.Add(sw);
                users.Add(name);
                try
                {
                    foreach (StreamWriter swClient in clients)
                    {
                        if (swClient != sw)
                        {
                            try
                            {

                                swClient.WriteLine(name + " has join");
                                swClient.Flush();
                            }
                            catch (IOException) { }
                        }
                    }
                }
                catch (InvalidOperationException) { }//Salta al cerrar muchos clientes a la vez
                while (!exit)
                {
                    try
                    {
                        message = sr.ReadLine();
                        if (message != null)
                        {
                            if (message.Length > 0)
                            {
                                switch (message)
                                {
                                    case "#exit":
                                        exit = true;
                                        break;
                                    case "#list":
                                        sw.WriteLine("\nThese are the clients");
                                        try
                                        {
                                            foreach (string user in users)
                                            {
                                                sw.WriteLine(user);
                                            }
                                            sw.WriteLine();
                                        }
                                        catch (InvalidOperationException) { }
                                        sw.Flush();
                                        break;
                                    default:
                                        try
                                        {
                                            foreach (StreamWriter swCliente in clients)
                                            {
                                                if (sw != swCliente)
                                                {
                                                    try
                                                    {

                                                        swCliente.WriteLine("{0}: {1}", name, message);
                                                        swCliente.Flush();
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch (InvalidOperationException) { }
                                        Console.WriteLine("{0}: {1}", name, message);
                                        sw.Flush();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
                clients.Remove(sw);
                Console.WriteLine(name + " has left");
                try
                {
                    foreach (StreamWriter swClient in clients)
                    {
                        try
                        {

                            swClient.WriteLine(name + " has left");
                            swClient.Flush();
                        }
                        catch (IOException) { }
                    }
                }
                catch (InvalidOperationException) { }//Salta al cerrar muchos clientes a la vez
                sw.Flush();
                sw.Flush();
                sw.Close();
                sr.Close();
                ns.Close();
            }
            catch (IOException) { }
            users.Remove(name);
            cliente.Close();
        }
    }
}
