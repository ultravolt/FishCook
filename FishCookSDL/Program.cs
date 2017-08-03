using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using SDL_Extensions;
using System.Diagnostics;

namespace FishCookSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            var rv = SDL.Init(SDL2.SDL.INIT_EVERYTHING);
            var sdlIntitialized = !Convert.ToBoolean(rv);
            if (sdlIntitialized)
            {
                var mode = new SDL.SDL_DisplayMode();
                var displayRect = new SDL.Rect();
                var displayCount = SDL.GetNumVideoDisplays();
                SDL.GetDisplayBounds(0, out displayRect);
                SDL.GetCurrentDisplayMode(0, out mode);
                int width = 1280, height = 720;//720p

                var left = (int)((mode.w - width) * .5);
                var top = (int)((mode.h - height) * .5);


                using (var window = new Window("Fish Cook", left, top, width, height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN, true))
                {
                    if (window.IsValid())
                    {
                        window.Show();
                        window.Raise();
                    }
                    var @event = new SDL.SDL_Event();
                    bool run = true;

                    var b = window.Renderer.LoadTexture("content/b.png");
                    var g = window.Renderer.LoadTexture("content/g.png");
                    var p = window.Renderer.LoadTexture("content/p.png");
                    var r = window.Renderer.LoadTexture("content/r.png");
                    var y = window.Renderer.LoadTexture("content/y.png");

                    window.Scene = new List<Sprite>();

                    var s1 = b.CreateSprite();
                    s1.X = 50;
                    s1.Y = 50;
                    s1.Z = 0;
                    s1.Scale = .5f;
                    window.Scene.Add(s1);

                    var s2 = y.CreateSprite();
                    s2.X = 100;
                    s2.Y = 100;
                    s2.Z = 1;
                    s2.Scale = .5f;
                    window.Scene.Add(s2);

                    var s3 = new Sprite(r)
                    {
                        X = 150,
                        Y = 150,
                        Z = 2,
                        Scale = .5f,
                    };
                    window.Scene.Add(s3);
                    SDL.SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "1");
                    window.Clear();
                    window.Present();

                    while (run)
                    {
                        SDL.SDL_PollEvent(out @event);
                        //while ( != 0)
                        //{
                        switch (@event.type)
                        {
                            case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:
                                var button = @event.button;
                                var point = new SDL.Point() { x = button.x, y = button.y };
                                var timestamp = new DateTime(button.timestamp);
                                var matches = window.Scene.Where(sprite => sprite.Contains(point)).ToList();
                                var brown = window.Scene.First();
                                matches.ForEach(sprite=>sprite.MouseDown(@event));
                                //button.button  1   byte
                                //button.clicks  1   byte
                                //button.padding1    0   byte
                                //button.state   1   byte
                                //button.timestamp   140630  uint
                                //button.@type   SDL_MOUSEBUTTONDOWN SDL2.SDL.SDL_EventType
                                //button.which   0   uint
                                //button.windowID    1   uint
                                //button.x   182 int
                                //button.y   169 int

                                break;
                            case SDL.SDL_EventType.SDL_QUIT:
                                run = false;
                                break;
                            case SDL.SDL_EventType.SDL_FIRSTEVENT:
                                Debug.WriteLine("First Event");
                                break;
                            case SDL.SDL_EventType.SDL_LASTEVENT:
                                Debug.WriteLine("Last Event");
                                break;

                        }
                        //}
                    }
                    //SDL.SDL_WaitEvent(out @event);
                    //var quit = @event.quit;
                }


            }
        }
    }
}
