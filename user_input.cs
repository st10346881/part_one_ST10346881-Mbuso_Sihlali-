using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace part_one_tut
{
    public class user_input
    {
        // declare variable and arraylist
        ArrayList respond = new ArrayList();
        ArrayList hidden = new ArrayList();

        
        private string name_of_user = string.Empty;
        private string asking_the_user = string.Empty;
        //constructer
        public user_input()
        {
            //and voice greeting
            voice_over();


            // add logo
            logo_img();


            system_dev();
         



            do
            {
                //recreating the interface
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("CyberAI:-> ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Good day, " + name_of_user + " How may I be at your service:");
                //changing the color of the username.
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.Write(name_of_user+ ": ");
                Console.ForegroundColor = ConsoleColor.White ;

                //prompting the question
                asking_the_user = Console.ReadLine();
                //then check if user enter exit
                if(asking_the_user == "exit")
                {
                    //display exit message
                    Console.ForegroundColor = ConsoleColor.Cyan ;
                    Console.Write("CyberAI:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Thank you for using Cyber AI, Good bye.");
                    break;
                }else
                {

                }


                design_interface(asking_the_user);

               

                //prompting the user to enter question
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("CyberAI:) ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("How can I assist you:");



                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name_of_user+": ");
                Console.ForegroundColor = ConsoleColor.White;
                string ask = Console.ReadLine();

                //declare variable and array
                ArrayList respond = new ArrayList();
                ArrayList hidden = new ArrayList();

                //then store
                respond.Add("password safety: \n create a password atleast 12 characters long. \n Use a combination of lower and upper case and special characters. \n Use auto generated password. ");
                respond.Add("phishing: \n Avoid sharing personal information. \n Use a two-facter authentification \n keep your and security tools up to date.");
                respond.Add("safe browsing: \n use a secure internet connection \n close unused accounts \n keep software and browsing udated");

                hidden.Add("tell");
                hidden.Add("me");
                hidden.Add("about");

                // split the question and store in the 1D array
                string[] filtered_responce = ask.Split(' ');
                ArrayList correct_responce = new ArrayList();

                // then display the answer using the for loop
                //as it search it should filter more

                Boolean found = false;

                for (int count = 0; count < filtered_responce.Length; count++)
                {
                    //then final filter 
                    if (!hidden.Contains(filtered_responce[count]))
                    {
                        //then assign to true
                        found = true;
                        //then add the value to the correct filtered
                        correct_responce.Add(filtered_responce[count]);




                    }



                }
                //then check if found
                if (found)
                {
                    for (int counting = 0; counting < correct_responce.Count; counting++)
                    {
                        //then display the answer
                        for (int count = 0; count < respond.Count; count++)
                        {
                            // then final display the found one
                            if (respond[count].ToString().Contains(correct_responce[counting].ToString()))
                            {
                                //output 
                                Console.WriteLine(respond[count].ToString());
                            }//end of if statement.
                        }//end of for loop nested
                    }
                }
                

            } while (asking_the_user != "exit");


            

        }// end of constructer

        //create a method name
        private void system_dev()
        {
            //Welcoming the user
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(".==================================================================================================================.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("||                                              CYBER AWARENESS AI CHATBOT:)                                      ||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("'=================================================================================================================='");
            Console.ForegroundColor = ConsoleColor.White;


            //creating chatbot design to ask user personal questions.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CyberAI:) ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter your name:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("User:-> ");

            Console.ForegroundColor = ConsoleColor.White;
            name_of_user = Console.ReadLine();

            



            

         






        }//end of class

        private void logo_img()
        {
            //get full location of the project

            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            //replace the bin and debug
            string new_location = full_location.Replace("bin\\Debug\\", "");

            //combining the path
            string full_path = Path.Combine(new_location, "image.png");

            //then time to use ascii

            //creating the BitMap class
            Bitmap image = new Bitmap(full_path);

            //then set the size
            image = new Bitmap(image, new Size(150, 100));

            //enter the inner loop
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = gray > 200 ? '.' : gray > 150 ? '*' : gray > 100 ? '0' : gray > 50 ? '#' : '@';
                    Console.Write(asciiChar);


                }

                // end of inner for loop
                Console.WriteLine();
            }

        }
            

            private void voice_over () 
        {
            //getting the full location of the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;


            //replacing the bin and the debug
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //try and catch
            try
            {
                //combine the paths
                string full_path = Path.Combine(new_path, "Recording 1.wav");

                // creating instance for SoundPlay class
                using (SoundPlayer play = new SoundPlayer(full_path))
                {

                    //play the file
                    play.PlaySync();
                }//end of using sound player


            }//end of try
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }//end of catch


        }//end of voice_over method.

        private void design_interface(string asked)
        {
            if (asked != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("CyberAI:) ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The purpose of this program is to alert you about cyber threats\n Topics include: \n Password Safety \n Phishing \n Safe browsing \n Type 'exit' to leave the aplication");

                //reseting color to white
                Console.ForegroundColor=ConsoleColor.White;
            }
            else
            {
                //exiting the application.
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("CyberAI:) ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Thank you for using AI Chatbot Goodbye");
                System.Environment.Exit(0);

            }// end of else statement
        }//end of design interface method.
        private void store_respond()
        {
            respond.Add("Password safety: ");
            respond.Add("\n Password must be 12 characters long");
            respond.Add("\n Password must have unique characters and use special keys");
            respond.Add("Phishing:");
            respond.Add("\n ");
            respond.Add("\n");
            respond.Add("Safe Browsing:");
            respond.Add("\n");


        }//end of store information method
        private void store_hidden()
        {
            hidden.Add("Tell ");
            hidden.Add("me");
            hidden.Add("About");
            hidden.Add("I ");
            hidden.Add("would ");
            hidden.Add("like");
            hidden.Add("to");
            hidden.Add("know");
            hidden.Add("more");
            hidden.Add("regarding");


        }



    }// end of method
    }//end of namespace


