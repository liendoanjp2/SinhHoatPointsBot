using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DongHanhDiscordBot.Commands
{
    class PointsCommands : BaseModule
    {
        List<User> listOfUsers;

        public PointsCommands()
        {
            listOfUsers = new List<User>();

            string inputFile = @"C:\Users\Philips\Desktop\LastLeaderBoard.txt";

            if (File.Exists(inputFile))
            {

                string[] lines = System.IO.File.ReadAllLines(inputFile);
                for(int i =  2; i < lines.Length; i++)
                {
                    User user = new User();

                    if (lines[i].Contains(')'))
                    {
                        //Do special parsing
                        string[] parts = lines[i].Split(')');
                        string[] inputParts = parts[1].Trim().Split(':');

                        user.userName = inputParts[0].Trim();
                        user.points = int.Parse(inputParts[1].Trim());

                    }
                    else
                    {
                        string[] inputParts = lines[i].Trim().Split(':');

                        user.userName = inputParts[0].Trim();
                        user.points = int.Parse(inputParts[1].Trim());
                    }

                    listOfUsers.Add(user);
                }


            }

        }

        [Command("addUser")]
        public async Task addUser(CommandContext ctx)
        {
            if (ctx.Member.Username.Contains("Yourguyphil"))
            {
                User user = new User();
                user.userName = ctx.RawArgumentString.Trim();
                user.points = 0;

                listOfUsers.Add(user);

                await ctx.Channel.SendMessageAsync(user.userName + " has been added as a player!!!").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Only Tr.Philips can register Users!").ConfigureAwait(false);
            }


        }

        [Command("awardPoints")]
        public async Task awardPoints(CommandContext ctx)
        {
            if (ctx.Member.Username.Contains("Yourguyphil"))
            {
                string[] input = ctx.RawArgumentString.Trim().Split("/");

                string userName = input[0];
                string points = input[1];
                User userThatWon = null;

                foreach (User user in listOfUsers)
                {
                    if (user.userName == userName)
                    {
                        user.points += int.Parse(points);
                        userThatWon = user;
                    }
                }

                await ctx.Channel.SendMessageAsync(userName + " has been awarded " + points + " Discord points! They now have " + userThatWon.points + " points! Congratulations!! :partying_face: ").ConfigureAwait(false);

            }
            else
            {
                await ctx.Channel.SendMessageAsync("Only Tr.Philips can award Discord points!").ConfigureAwait(false);
            }
        }

        [Command("deductPoints")]
        public async Task deductPoints(CommandContext ctx)
        {
            if (ctx.Member.Username.Contains("Yourguyphil"))
            {
                string[] input = ctx.RawArgumentString.Trim().Split("/");

                string userName = input[0];
                string points = input[1];
                User userThatWon = null;

                foreach (User user in listOfUsers)
                {
                    if (user.userName == userName)
                    {
                        user.points += int.Parse(points)*-1;
                        userThatWon = user;
                    }
                }

                await ctx.Channel.SendMessageAsync(userName + " has been deducted " + points + " Discord points! They now have " + userThatWon.points + " points! Womp Womp :crying_cat_face: ").ConfigureAwait(false);

            }
            else
            {
                await ctx.Channel.SendMessageAsync("Only Tr.Philips can deduct Discord points!").ConfigureAwait(false);
            }
        }

        [Command("viewLeaderBoard")]
        public async Task viewLeaderBoard(CommandContext ctx)
        {
            listOfUsers.Sort((x, y) => x.points.CompareTo(y.points));
            listOfUsers.Reverse();
            string output = "Discord Points Leaderboard!\n ------------------------------\n";

            int counter = 1;

            foreach(User user in listOfUsers)
            {
                if(counter == 1)
                {
                    output += "(1st) ";
                } 
                else if(counter == 2)
                {
                    output += "(2nd) ";
                }
                else if (counter == 3)
                {
                    output += "(3rd) ";
                }

                output += user.userName + " : " + user.points + "\n";
                counter++;
            }

            await ctx.Channel.SendMessageAsync(output).ConfigureAwait(false);
        }


        [Command("NghiaSi")]
        public async Task nghiaSi(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Chinh Phục!!!").ConfigureAwait(false);
        }

        [Command("ComfortKhang")]
        public async Task ComfortKhang(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("It's ok Khang, Jesus Loves you still. <3").ConfigureAwait(false);
        }

        [Command("ComfortKhang2")]
        public async Task ComfortKhang2(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://www.youtube.com/watch?v=owx3ao42kwI").ConfigureAwait(false);
        }

        [Command("HiepSi")]
        public async Task hiepSi(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Dấn Thân!!!").ConfigureAwait(false);
        }

        protected override void Setup(DiscordClient client)
        {
            throw new System.NotImplementedException();
        }
    }
}
