﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Platform;
using Gdk;
using Gtk;
using Action = System.Action;
using WindowEdge = Avalonia.Controls.WindowEdge;

namespace Avalonia.Gtk
{
    class EmbeddableImpl : TopLevelImpl, IEmbeddableWindowImpl
    {
#pragma warning disable CS0067 // Method not used
        public event Action LostFocus;
#pragma warning restore CS0067

        public EmbeddableImpl(DrawingArea area) : base(area)
        {
            area.Events = EventMask.AllEventsMask;
            area.SizeAllocated += Plug_SizeAllocated;
        }

        public EmbeddableImpl() : this(new PlatformHandleAwareDrawingArea())
        {
        }

        private void Plug_SizeAllocated(object o, SizeAllocatedArgs args)
        {
            Resized?.Invoke(new Size(args.Allocation.Width, args.Allocation.Height));
        }

        public override Size ClientSize
        {
            get { return new Size(Widget.Allocation.Width, Widget.Allocation.Height); }
        }
        
    }
}
