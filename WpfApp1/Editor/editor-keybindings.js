var te = window.textEditor;

te.keyBindings = {
  setupKeyBindings: function () {
    setTimeout(function () {
     //var kbJson = te.mm.textbox.GetKeyBindingsJson();
      var keyBindings = [
          {
              "Id": "DistractionFreeMode",
              "Key": "Alt+Shift+Enter",
              "CommandName": "DistractionFreeMode",
              "CommandParameter": "Toggle"
          },
          {
              "Id": "PresentationMode",
              "Key": "F11",
              "CommandName": "PresentationMode",
              "CommandParameter": "Toggle"
          },
          {
              "Id": "TogglePreviewBrowser",
              "Key": "F12",
              "CommandName": "TogglePreviewBrowser",
              "CommandParameter": "Toggle"
          },
          {
              "Id": "ToggleLeftSidebarPanel",
              "Key": "Ctrl+Shift+B",
              "CommandName": "ToggleLeftSidebarPanel",
              "CommandParameter": null
          },
          {
              "Id": "ShowExternalBrowser",
              "Key": "Shift+F12",
              "CommandName": "ShowExternalBrowser",
              "CommandParameter": "Toggle"
          },
          {
              "Id": "NewDocument",
              "Key": "Ctrl+N",
              "CommandName": "NewDocument",
              "CommandParameter": null
          },
          {
              "Id": "OpenDocument",
              "Key": "Ctrl+O",
              "CommandName": "OpenDocument",
              "CommandParameter": null
          },
          {
              "Id": "SaveDocument",
              "Key": "Ctrl+S",
              "CommandName": "SaveDocument",
              "CommandParameter": null
          },
          {
              "Id": "SaveAs",
              "Key": "Ctrl+Shift+S",
              "CommandName": "SaveAs",
              "CommandParameter": null
          },
          {
              "Id": "SaveAll",
              "Key": "Alt+Shift+S",
              "CommandName": "SaveAll",
              "CommandParameter": null
          },
          {
              "Id": "PrintPreview",
              "Key": "Ctrl+P",
              "CommandName": "PrintPreview",
              "CommandParameter": null
          },
          {
              "Id": "RefreshBrowserContentCommand",
              "Key": "Ctrl+Shift+R",
              "CommandName": "RefreshBrowserContentCommand",
              "CommandParameter": null
          },
          {
              "Id": "CloseActiveDocument",
              "Key": "Ctrl+F4",
              "CommandName": "CloseActiveDocument",
              "CommandParameter": null
          },
          {
              "Id": "CloseActiveDocument2",
              "Key": "Ctrl+W",
              "CommandName": "CloseActiveDocument",
              "CommandParameter": null
          },
          {
              "Id": "CommitToGit",
              "Key": "Alt+G",
              "CommandName": "CommitToGit",
              "CommandParameter": null
          },
          {
              "Id": "ToggleWordWrap",
              "Key": "Alt+Z",
              "CommandName": "ToggleWordWrap",
              "CommandParameter": null
          },
          {
              "Id": "ShowHelp",
              "Key": "F1",
              "CommandName": "ShowHelp",
              "CommandParameter": null
          },
          {
              "Id": "ReloadEditor",
              "Key": "F5",
              "CommandName": "ReloadEditor",
              "CommandParameter": null
          },
          {
              "Id": "ReloadEditor2",
              "Key": "Ctrl+F5",
              "CommandName": "ReloadEditor",
              "CommandParameter": null
          },
          {
              "Id": "EditorCommand_Softbreak",
              "Key": "Shift+Enter",
              "CommandName": "EditorCommand",
              "CommandParameter": "softbreak"
          },
          {
              "Id": "EditorCommand_Bold",
              "Key": "Ctrl+B",
              "CommandName": "EditorCommand",
              "CommandParameter": "bold"
          },
          {
              "Id": "EditorCommand_Italic",
              "Key": "Ctrl+I",
              "CommandName": "EditorCommand",
              "CommandParameter": "italic"
          },
          {
              "Id": "EditorCommand_Href",
              "Key": "Ctrl+K",
              "CommandName": "EditorCommand",
              "CommandParameter": "href"
          },
          {
              "Id": "EditorCommand_Href2",
              "Key": "Ctrl+Shift+K",
              "CommandName": "EditorCommand",
              "CommandParameter": "href2"
          },
          {
              "Id": "EditorCommand_List",
              "Key": "Ctrl+L",
              "CommandName": "EditorCommand",
              "CommandParameter": "list"
          },
          {
              "Id": "EditorCommand_Emoji",
              "Key": "Ctrl+J",
              "CommandName": "EditorCommand",
              "CommandParameter": "emoji"
          },
          {
              "Id": "EditorCommand_Image",
              "Key": "Alt+I",
              "CommandName": "EditorCommand",
              "CommandParameter": "image"
          },
          {
              "Id": "EditorCommand_Image2",
              "Key": "Alt+Shift+I",
              "CommandName": "EditorCommand",
              "CommandParameter": "image2"
          },
          {
              "Id": "EditorCommand_Quote",
              "Key": "Ctrl+Q",
              "CommandName": "EditorCommand",
              "CommandParameter": "quote"
          },
          {
              "Id": "EditorCommand_Code",
              "Key": "Alt+C",
              "CommandName": "EditorCommand",
              "CommandParameter": "code"
          },
          {
              "Id": "EditorCommand_InlineCode",
              "Key": "Ctrl+`",
              "CommandName": "EditorCommand",
              "CommandParameter": "inlinecode"
          },
          {
              "Id": "FindNext",
              "Key": "F3",
              "CommandName": "FindNext",
              "CommandParameter": null
          },
          {
              "Id": "FindInFiles",
              "Key": "Ctrl+Shift+F",
              "CommandName": "FindInFiles",
              "CommandParameter": null
          },
          {
              "Id": "TogglePreviewBrowser",
              "Key": "F12",
              "CommandName": "TogglePreviewBrowser",
              "CommandParameter": null
          },
          {
              "Id": "DeleteCurrentLine",
              "Key": "Shift+Del",
              "CommandName": "DeleteCurrentLine",
              "CommandParameter": null
          },
          {
              "Id": "NextTab",
              "Key": "Ctrl+Tab",
              "CommandName": "NextTab",
              "CommandParameter": null
          },
          {
              "Id": "PreviousTab",
              "Key": "Ctrl+Shift+Tab",
              "CommandName": "PreviousTab",
              "CommandParameter": null
          },
          {
              "Id": "ZoomEditorDown",
              "Key": "Ctrl+-",
              "CommandName": "ZoomEditorDown",
              "CommandParameter": null
          },
          {
              "Id": "ZoomEditorUp",
              "Key": "Ctrl+=",
              "CommandName": "ZoomEditorUp",
              "CommandParameter": null
          },
          {
              "Id": "ZoomEditorUp2",
              "Key": "Ctrl++",
              "CommandName": "ZoomEditorUp",
              "CommandParameter": null
          },
          {
              "Id": "CopyAsHtml",
              "Key": "Ctrl+Shift+C",
              "CommandName": "CopyAsHtml",
              "CommandParameter": null
          },
          {
              "Id": "PasteMarkdownFromHtml",
              "Key": "Ctrl+Shift+V",
              "CommandName": "PasteMarkdownFromHtml",
              "CommandParameter": null
          },
          {
              "Id": "RemoveMarkdownFormatting",
              "Key": "Ctrl+Shift+Z",
              "CommandName": "RemoveMarkdownFormatting",
              "CommandParameter": null
          },
          {
              "Id": "Paste2",
              "Key": "Shift+Insert",
              "CommandName": "Paste2",
              "CommandParameter": null
          },
          {
              "Id": "Paste",
              "Key": "Ctrl+V",
              "CommandName": "Paste",
              "CommandParameter": null
          },
          {
              "Id": "Copy",
              "Key": "Ctrl+C",
              "CommandName": "Copy",
              "CommandParameter": null
          },
          {
              "Id": "NextSpellCheckError",
              "Key": "F7",
              "CommandName": "NextSpellCheckError",
              "CommandParameter": null
          },
          {
              "Id": "PreviousSpellCheckError",
              "Key": "Shift+F7",
              "CommandName": "PreviousSpellCheckError",
              "CommandParameter": null
          },
          {
              "Id": "AltEDefaultBinding",
              "Key": "Alt+E",
              "CommandName": "DoNothing",
              "CommandParameter": null
          },
          {
              "Id": "SidebarTabActivationCommand",
              "Key": "Ctrl-1",
              "CommandName": "SidebarTabActivationCommand",
              "CommandParameter": "1"
          },
          {
              "Id": "SidebarTabActivationCommand2",
              "Key": "Ctrl-2",
              "CommandName": "SidebarTabActivationCommand",
              "CommandParameter": "2"
          },
          {
              "Id": "SidebarTabActivationCommand3",
              "Key": "Ctrl-3",
              "CommandName": "SidebarTabActivationCommand",
              "CommandParameter": "3"
          },
          {
              "Id": "SidebarTabActivationCommand4",
              "Key": "Ctrl-4",
              "CommandName": "SidebarTabActivationCommand",
              "CommandParameter": "4"
          }
      ];
      //te.keyBindings = keyBindings;

      for (var i = 0; i < keyBindings.length; i++) {
        var kb = keyBindings[i];

        if (!kb.CommandName)
          continue;

        var handlerName = kb.CommandName[0].toLowerCase() + kb.CommandName.substr(1);
        console.log(handlerName);
        var handler = eval("te.keyBindings." + handlerName);
        if (!handler)
          continue;

        console.log("-- ADDED: " + handlerName);
        //alert(kb.CommandName + ": " + kb.Key + " - " + handler + " " + typeof(handler));
        te.editor.commands.addCommand({
          name: kb.Id,
          bindKey: { win: kb.Key },
          exec: handler,
          hint: kb.CommandParameter
        });

      }
    }, 500);
  },
  // generic editor commands (bold, italic, href etc.) - hint is the action
  editorCommand: function () {
      
    var cmd = this;
    te.keyboardCommand("EditorCommand", cmd.hint);
    event.preventDefault();
    return null;
  },
  // donothing
  doNothing: function () {  return null; },
  // this one requires explicit handling in WPF
  insertCodeBlock: function() {
    te.keyboardCommand("InsertCodeBlock");
  },
  saveDocument: function () {
    //te.mm.textbox.IsDirty(true); // force document to update
    te.keyboardCommand("SaveDocument");
  },
  newDocument: function () {
    te.keyboardCommand("NewDocument");
    // do nothing but:
    // keep ctrl-n browser behavior from happening
    // and let WPF handle the key
  },
  openDocument: function () {
    te.editor.blur(); // HACK: avoid letter o insertion into document IE bug
    te.keyboardCommand("OpenDocument");
    setTimeout(function () { te.editor.focus(); }, 20);
  },
  reloadEditor: function () {
    te.editor.blur(); // HACK: avoid letter internal F5 insertion into document IE bug
    te.keyboardCommand("ReloadEditor");
    setTimeout(function () { te.editor.focus(); }, 20);
  },
  showHelp: function () { te.keyboardCommand("ShowHelp") },

  // find again redirect
  findNext: function () { te.editor.execCommand("findnext") },

  deleteCurrentLine: te.deleteCurrentLine,

  // try to move between tabs
  nextTab: function () { te.keyboardCommand("NextTab"); },
  previousTab: function () { te.keyboardCommand("PreviousTab"); },

  // take over Zoom keys and manually zoom
  zoomEditorDown: function () {
    te.keyboardCommand("ZoomEditorDown");
    return null;
  },
  zoomEditorUp: function () {
    te.keyboardCommand("ZoomEditorUp");
    return null;
  },


  // remove markdown formatting
  removeMarkdownFormatting: function () { te.keyboardCommand("RemoveMarkdownFormatting"); },

  // Capture paste operation in WPF to handle Images
  paste: function (editor, args) {
    // text use default behavior
    if (clipboardData.getData("text")) {
      te.editor.$handlePaste(args);
      return;
    }  
    // anything else - let MM handle it
    te.mm.textbox.PasteOperation();
  },
  paste2: function () {
    te.mm.textbox.PasteOperation();
    //setTimeout(function() { alert('test'); }, 1000);
  },
  copy: function() {
    te.mm.textbox.CopyOperation();
  },
  nextSpellCheckError: function () {
    var pos = te.getCursorPosition();
    var markers = te.editor.session.getMarkers(true);

    var range;
    for (var key in markers) {
      range = markers[key].range;
      if (range.end.row > pos.row || range.end.row === pos.row && range.end.column > pos.column) {
        te.editor.scrollToLine(range.end.row);
        var sel = te.editor.getSelection();
        sel.setSelectionRange(range);
        return;
      }
    }

    if (te.editor.renderer.getLastVisibleRow() >= te.editor.session.getLength() - 1)
      return;

    te.editor.gotoPageDown();
    sc.contentModified = true;
    sc.spellCheck();

    setTimeout(te.keyBindings.nextSpellCheckError, 200);
  },
  previousSpellCheckError: function () {
    var pos = te.getCursorPosition();
    var markers = te.editor.session.getMarkers(true);

    var keys = [];
    for (var key in markers)
      keys.push(key);

    while (true) {
      var key = keys.pop();
      if (!key)
        break;

      var range = markers[key].range;
      if (range.end.row < pos.row || range.end.row === pos.row && range.end.column < pos.column) {
        te.editor.scrollToLine(range.end.row);
        te.setSelectionRange(range);
        return;
      }
    }

    if (te.editor.renderer.getFirstVisibleRow() < 2)
      return;

    te.editor.gotoPageUp();
    sc.contentModified = true;
    sc.spellCheck();
    setTimeout(te.keyBindings.nextSpellCheckError, 200);
  }
};
