# Sinh Hoat Points

## Overview

Keep track of participation and award ourstanding achievement! Gamify virtual sinh hoat!

## Backgorund

Doan Dong Hanh chose to move Sinh Hoat into Discord. In this, we are able to use bots to help conduct sinh hoat! :) 

## Here's a Demo! 

![](https://github.com/liendoanjp2/SinhHoatPointsBot/blob/master/Demo%20Screenshots/Demo.PNG)

## Technology used

Built with

  - C#, Discord Bot library

## Features

- Add users to a "Sinh Hoat"
- Add and deduct points
- On app close, write to a text file which allows the bot to restart with previous data

## How to use

1. Request a API token from: https://discord.com/developers
2. Add the token in *config.json*
3. Modify PointsCommands.cs to your admins userids and local paths.
4. Invite the bot to your server.
4. Run the app! (Add users with !addUser) first!


Commands:

!addUser {Person's Name} (Adds a user)
!awardPoints {Person's Name}/{Point Value} (Awards points to a user)
!deductPoints {Person's Name}/{Point Value} (Deducts points to a user)

See !help for more fun commands :) 

## Development!

Let's make this more awesome! I wrote this one evening for sinh hoat the next day. Fork off and let's build something more awesome! Open to any feature ideas!
