// Display.cs
using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages the display of ASCII art for the Cybersecurity Awareness Chatbot.
    /// </summary>
    class Display
    {
        /// <summary>
        /// Displays an ASCII art logo for the Cybersecurity Awareness Chatbot.
        /// Uses colored text to enhance visual appeal.
        /// </summary>
        public void DisplayASCIIArt()
        {
            // Set text color to cyan for a professional and visually distinct look
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                                                                                                                 
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                      %@@%                %@@%                                      
                                     #@@@@@     %@@%     @@@@@#                                     
                                      @@@@%    @@%%@@    %@@@@                                      
                                       @@@      @@@@      @@@                                       
                                       @@@      %@@%      @@@                                       
                                       @@@      %@@%      @@@                                       
                                       %@@%     %@@%     %@@%                                       
                                         %@@#   %@@%   #@@%                                         
                                          #@@@  %@@%  @@@#                                          
                                           @@@ %%@@%% @@@                                           
                                         %%@@@@@@@@@@@@@@%%                                         
                                      #@@@%%            %%@@@#                                      
                                    @@@@#                  #@@@#                                    
               ##                 %@@%                        #@@%                 ##               
             %@@@@%@@@@@%        %@@          %@@@@@@%          @@%        %@@@@@%@@@@%             
             @@@@@@@@@@@@@      %@@         %@@%@@@@%@@%         @@%      @@@@@@@@@@@@@             
              %@@#      %@@%   %@@         @@%        %@%:        @@%   %@@%      #@@%              
                          %@@@@@@%        @@@          @@@        %@@@@@@%                          
                              @@@         @@@          @@@         @@@                              
               %@@@%          @@#       %@@@@@@@@@@@@@@@@@@%       #@@          %@@@%               
              %@@#@@@@@@@@@@@@@@=       %@@      %%      @@%       =@@@@@@@@@@@@@@#@@%              
               %@@@%          @@#       %@@    %@@@@#    @@%       #@@          %@@@%               
                              @@@       %@@    %@@@@%    @@%       @@@                              
                          %@@@@@@%      %@@     %@@%     @@%      %@@@@@@%                          
              %@@#      %@@%   %@@      #@%     #@@#     @@%      @@%   %@@%      #@@%              
             @@@@@@@@@@@@@      %@@     +@@*            #@@%     @@%      @@@@@@@@@@@@@             
             %@@@@%@@@@@%        %@@    -@@@@@@@@@@@@@@@@@@     @@%        %@@@@@%@@@@%             
               %#                 #@@%                        %@@%                 ##.              
                                    #@@@#                  #@@@@                                    
                                      #@@@%              %@@@#                                      
                                         @@@@@@@@@@@@@@@@@@                                         
                                           @@@ %%@@%% @@@                                           
                                           @@@  %@@%  @@@                                           
                                         %@@%   %@@%   %@@%                                         
                                       %@@@     %@@%     @@@%                                       
                                       @@@      %@@%      @@@                                       
                                       @@@      %@@%      @@@                                       
                                       @@@      @@@@      @@@                                       
                                      @@@@%    @@@@@@    %@@@@                                      
                                     #@@@@@     %@@%     @@@@@#                                     
                                      %@@%                %@@+                                      
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                                                                                                                                                                                                           
            ");
            Console.WriteLine("Cybersecurity Awareness Bot\n");
            Console.ResetColor(); // Reset to default color after display

            // Add a decorative border for readability
            Console.WriteLine(new string('-', 60));
        }
    }
}