# What is this?
This is a total rip-off of speed runs live

## Who are you and why are you doing this?
I'm joro - I used to be a speed runner (not a very good one) and I have to admit that i hated using speedrunslive a couple years ago when I was speedrunning quite actively, I don't do as much in the community anymore apart from watch (want to get back into it) I can't imagine what it's like now.

I understand that it's weird for someone so far out of the community is doing this, and this i why I think the open source nature of *everything* is so important, if I happen to dissapear or haven't got the time to do this anymore someone can fork what I have and carry on.

## Why?
I think it's time that we admit to ourselves that speed runs live as a site is not getting any better, there are certain thigs that I have identified that can be vastly improved upon, firstly I propose that a site is created that emulates all of the current functionality of speedruns live but once it is complete we add more what has been missing from that site for so long!

## I've thought of something cool I want to add! 
Awesome - file an issue (if you would like to help contribute then you can do so by reading on about how to do that)

## So what do you think is missing?

### Open Source
This increases the bus factor - I'm guessing that if this is a hit I will hand it off to some more people to look after, let's people contribute to make this place the best it can be.

### Mobile Friendlyness
I think it is fair to say that browser traffic has moved away from desktop - most people are watching from a tablet or from a phone, best way to use this information is to use a css framework that is setup to be responsive.

### Discord bot
No one uses MIRC - or if they do they use it literally to setup races and nothing else, I believe a discord bot would help the community immensly

### Multiple streaming sites
Turns out there is more than one streaming site, I beleve that speedruns live only works with twitch so there is a goal that this site will work with mixer, youtube and any others that come along so those runners can get representation.

### Non-https
No reason not to be these days, especially a website where you are signing into. good thing it's not taking payments - hoping this site will be secure from the off.


# Note:
If speedruns live implements all of these changes I am happy enough to close down this site and use that as a primary source for speedruns - I agree that having a split in the community is a bad thing, I just think the site owners need a swift kick up the rear end (some competition) to get them thinking about these things

# Hosting
This will be hosted on Azure (CI/CD to follow sooner or later) on a subscription most likely in the UK this may or may not change depending on how far we can take it

## Who will fund this?
Not something I'm thinking about right now - maybe we'll think about donations sooner or later, or maybe advertisements, I'm not 100% but for right now it's small enough to fund on my own.

# Development 

## Prerequisites

- Docker
- Dot net core 3.1 (LTS)
- Modern c# ide (VS 2019, VSCode, Rider)
- Azure functions dev kit (https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local)

### To run the website 
run the `docker-compose up -d` command in the src folder (in your favourite terminal) this will download and run a docker version of sql server on a specific port, the debug the website, it should then create the database and seed data into the database (for now). 

## Why blazor and not x framework
I'll be the first to admit that I dislike javascript and I want to play around with what I think will soon be the default framework for c# developers

You can learn about blazor here - https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor

### Will you be moving to client side blazor when that's a thing?
Maybe - it depends on how difficult the transition is.

## Why c#/aspnet?
That's what I am most familier with, it was a purely selfish choice

# So what's missing 
Right now a lot! But hopefully by the end of Febuary/March this will all be done

- [ ] Registering users
- [ ] Races
- [ ] Leaderboards
- [ ] Bots for races
- [ ] REST API for third parties (livesplit is a good example here)

*Check the open issues to help out!*

# Contributing

We need your help!

You can browse the [Issues](https://github.com/joro550/furry-telegram/issues) to find good issues to get started with. Select one that is not already done or in progress, assign yourself, and drag it over to "In Progress".

 1. [Fork](https://github.com/joro550/furry-telegram/fork) the project
 2. Clone your forked repo: `git clone https://github.com/joro550/furry-telegram.git`
 3. Create your feature/bugfix branch: `git checkout -b new-feature`
 4. Commit your changes to your new branch: `git commit -am 'Add a new feature'`
 5. Push to the branch: `git push origin new-feature`
 6. Create a new Pull Request!








