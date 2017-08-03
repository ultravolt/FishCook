#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013-2015 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

#region Using Statements
using System;
using System.Runtime.InteropServices;
#endregion

namespace SDL2
{
    public static class TTF
    {
        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        private const string nativeLibName = "SDL2_ttf.dll";

        #endregion

        #region SDL_ttf.h

        /* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
        public const int SDL_TTF_MAJOR_VERSION = 2;
        public const int SDL_TTF_MINOR_VERSION = 0;
        public const int SDL_TTF_PATCHLEVEL = 12;

        public const int UNICODE_BOM_NATIVE = 0xFEFF;
        public const int UNICODE_BOM_SWAPPED = 0xFFFE;

        public const int TTF_STYLE_NORMAL = 0x00;
        public const int TTF_STYLE_BOLD = 0x01;
        public const int TTF_STYLE_ITALIC = 0x02;
        public const int TTF_STYLE_UNDERLINE = 0x04;
        public const int TTF_STYLE_STRIKETHROUGH = 0x08;

        public const int TTF_HINTING_NORMAL = 0;
        public const int TTF_HINTING_LIGHT = 1;
        public const int TTF_HINTING_MONO = 2;
        public const int TTF_HINTING_NONE = 3;

        public static void SDL_TTF_VERSION(out SDL.SDL_version X)
        {
            X.major = SDL_TTF_MAJOR_VERSION;
            X.minor = SDL_TTF_MINOR_VERSION;
            X.patch = SDL_TTF_PATCHLEVEL;
        }

        [DllImport(nativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_LinkedVersion();
        public static SDL.SDL_version TTF_LinkedVersion()
        {
            SDL.SDL_version result;
            IntPtr result_ptr = INTERNAL_TTF_LinkedVersion();
            result = (SDL.SDL_version)Marshal.PtrToStructure(
                result_ptr,
                typeof(SDL.SDL_version)
            );
            return result;
        }

        [DllImport(nativeLibName, EntryPoint = "TTF_ByteSwappedUNICODE", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_ByteSwappedUNICODE(int swapped);

        [DllImport(nativeLibName, EntryPoint = "TTF_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_Init();

        /* IntPtr refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFont(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string file,
            int ptsize
        );

        /* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFontRW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontRW(
            IntPtr src,
            int freesrc,
            int ptsize
        );

        /* IntPtr refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontIndex(
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string file,
            int ptsize,
            long index
        );

        /* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        [DllImport(nativeLibName, EntryPoint = "TTF_OpenFontIndexRW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontIndexRW(
            IntPtr src,
            int freesrc,
            int ptsize,
            long index
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GetFontStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontStyle(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SetFontStyle", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontStyle(IntPtr font, int style);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GetFontOutline", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontOutline(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SetFontOutline", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontOutline(IntPtr font, int outline);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GetFontHinting", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontHinting(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SetFontHinting", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontHeight", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontHeight(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontAscent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontAscent(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontDescent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontDescent(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontLineSkip", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontLineSkip(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GetFontKerning", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerning(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SetFontKerning", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaces", CallingConvention = CallingConvention.Cdecl)]
        public static extern long TTF_FontFaces(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceIsFixedWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string TTF_FontFaceFamilyName(
            IntPtr font
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler), MarshalCookie = LPUtf8StrMarshaler.LeaveAllocated)]
        public static extern string TTF_FontFaceStyleName(
            IntPtr font
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GlyphIsProvided", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_GlyphMetrics", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics(
            IntPtr font,
            ushort ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SizeText", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeText(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            out int w,
            out int h
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeUTF8(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            out int w,
            out int h
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_SizeUNICODE", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeUNICODE(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            out int w,
            out int h
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderText_Solid", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUTF8_Solid(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUNICODE_Solid", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderGlyph_Solid", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Solid(
            IntPtr font,
            ushort ch,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderText_Shaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUTF8_Shaded(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUNICODE_Shaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderGlyph_Shaded", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Shaded(
            IntPtr font,
            ushort ch,
            SDL.Color fg,
            SDL.Color bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderText_Blended", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUTF8_Blended(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUNICODE_Blended", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderText_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended_Wrapped(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPStr)]
                string text,
            SDL.Color fg,
            uint wrapped
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUTF8_Blended_Wrapped(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LPUtf8StrMarshaler))]
                string text,
            SDL.Color fg,
            uint wrapped
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderUNICODE_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
            IntPtr font,
            [In()] [MarshalAs(UnmanagedType.LPWStr)]
                string text,
            SDL.Color fg,
            uint wrapped
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_RenderGlyph_Blended", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Blended(
            IntPtr font,
            ushort ch,
            SDL.Color fg
        );

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "TTF_CloseFont", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_CloseFont(IntPtr font);

        [DllImport(nativeLibName, EntryPoint = "TTF_Quit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_Quit();

        [DllImport(nativeLibName, EntryPoint = "TTF_WasInit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_WasInit();

        /* font refers to a TTF_Font* */
        [DllImport(nativeLibName, EntryPoint = "SDL_GetFontKerningSize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetFontKerningSize(
            IntPtr font,
            int prev_index,
            int index
        );

        #endregion
    }
}
