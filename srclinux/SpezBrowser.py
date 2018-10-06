import gi
gi.require_version('Gtk', '3.0')
gi.require_version('WebKit', '3.0')
from gi.repository import Gtk, WebKit
import os
import sys

def on_abtdlg(go_back_button):
   about = Gtk.AboutDialog()
   about.set_program_name("Spez Browser")
   about.set_version("Version 9.0")
   about.set_authors("Sarp Ertoksoz, Mary Icoz")
   about.set_copyright("(C) 2018 Spez Inc. Some Rights Reserved.")
   about.set_comments("The Quantum speed of web.\nPowered with WebKit.")
   about.set_website("https://spezcomputer.weebly.com/")
   about.run()
   about.destroy()

def on_enter(entry):
 url = entry.get_text()
 print(url)
 webview.open("http://" + url)

def on_clicked_back(go_back_button):
 webview.go_back()

def on_clicked_next(go_next_button):
 webview.go_forward()

def on_clicked_refresh(refresh_button):
 webview.reload()

window = Gtk.Window()
window.set_wmclass ("Spez Browser", "Spez Browser")
window.resize(800,600)
window.connect("destroy", Gtk.main_quit)
window.set_title("Spez Browser")

scroller = Gtk.ScrolledWindow()
window.add(scroller)
webview = WebKit.WebView()
webview.open(os.path.dirname(os.path.realpath(__file__)) + "/data/htmldoc/new-tab.html")
scroller.add(webview)

headerbar = Gtk.HeaderBar()
headerbar.set_show_close_button(True)

entry = Gtk.Entry()
entry.connect("activate", on_enter)

go_back_button = Gtk.Button()
go_back_arrow = Gtk.Image.new_from_icon_name("go-previous", Gtk.IconSize.SMALL_TOOLBAR)
go_back_button.add(go_back_arrow)
headerbar.pack_start(go_back_button)
go_back_button.connect("clicked", on_clicked_back)

go_next_button = Gtk.Button()
go_next_arrow = Gtk.Image.new_from_icon_name("go-next", Gtk.IconSize.SMALL_TOOLBAR)
go_next_button.add(go_next_arrow)
headerbar.pack_start(go_next_button)
go_next_button.connect("clicked", on_clicked_next)

refresh_button = Gtk.Button()
refresh_arrow = Gtk.Image.new_from_icon_name("reload", Gtk.IconSize.SMALL_TOOLBAR)
refresh_button.add(refresh_arrow)
headerbar.pack_start(refresh_button)
refresh_button.connect("clicked", on_clicked_refresh)

about_button = Gtk.Button()
about_arrow = Gtk.Image.new_from_icon_name("info", Gtk.IconSize.SMALL_TOOLBAR)
about_button.align = Gtk.Align.END;
about_button.add(about_arrow)
headerbar.pack_start(about_button)
about_button.connect("clicked", on_abtdlg)

if os.path.isfile("/home/" + os.getlogin() + "/.config/spez_browser_first_open") and os.access("/home/" + os.getlogin() + "/.config/spez_browser_first_open", os.R_OK):
    os.remove("/home/" + os.getlogin() + "/.config/spez_browser_first_open")
    webview.open(os.path.dirname(os.path.realpath(__file__)) + "/data/htmldoc/welcome.html")

headerbar.set_custom_title(entry)
window.set_titlebar(headerbar)
window.set_position(Gtk.WindowPosition.CENTER)
window.show_all()
Gtk.main()

