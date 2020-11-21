define("ace/theme/vscodelight",["require","exports","module","ace/lib/dom"], function(require, exports, module) {

exports.isDark = false;
exports.cssClass = "ace-vscodelight";
exports.cssText = ".ace-vscodelight {\
background: #f9f9f9;\
color: #111;  \
font-weight: normal;\
}\
.ace-vscodelight .ace_gutter {\
background: #f2f2f2; \
}\
.ace-vscodelight .ace_support.ace_function {\
color: teal;\
}\
.ace_underline {\
color: #a31515;\
cursor: pointer;\
}\
.ace-vscodelight .ace_print-margin {\
width: 1px;\
background: #e8e8e8;\
}\
.ace-vscodelight .ace_fold {\
background-color: #6B72E6;\
}\
.ace-vscodelight {\
background-color: #FCFCFC;\
color: #222;\
}\
.ace-vscodelight .ace_cursor {\
color: black;\
}\
.ace-vscodelight .ace_invisible {\
color: rgb(191, 191, 191);\
}\
.ace-vscodelight .ace_storage, \
.ace-vscodelight .ace_keyword {\
color: #0000ff;\
}\
.ace-vscodelight .ace_constant {\
color: rgb(197, 6, 11);\
}\
.ace-vscodelight .ace_constant.ace_buildin {\
color: orange;\
}\
.ace-vscodelight .ace_constant.ace_language {\
color: teal;\
}\
.ace-vscodelight .ace_constant.ace_library {\
color: rgb(6, 150, 14);\
}\
.ace-vscodelight .ace_invalid {\
background-color: rgba(255, 0, 0, 0.1);\
color: red;\
}\
.ace-vscodelight .ace_support.ace_constant {\
color: rgb(6, 150, 14);\
}\
.ace-vscodelight .ace_support.ace_type, .ace-vscodelight .ace_support.ace_class {\
color: rgb(109, 121, 222);\
}\
.ace-vscodelight .ace_keyword.ace_operator {\
color: blue;\
}\
.ace-vscodelight .ace_string {\
color: maroon;\
}\
.ace-vscodelight .ace_comment {\
color: green;\
}\
.ace-vscodelight .ace_comment.ace_doc {\
color: rgb(0, 102, 255);\
}\
.ace-vscodelight .ace_comment.ace_doc.ace_tag {\
color: rgb(128, 159, 191);\
}\
.ace-vscodelight .ace_constant.ace_numeric {\
color: rgb(0, 0, 205);\
}\
.ace-vscodelight .ace_variable {\
color: rgb(49, 132, 149);\
}\
.ace-vscodelight .ace_xml-pe {\
color: rgb(104, 104, 91);\
}\
.ace-vscodelight .ace_entity.ace_name.ace_function {\
color: #0000A2;\
}\
.ace-vscodelight .ace_list {\
color: rgb(185, 6, 144);\
}\
.ace-vscodelight .ace_meta.ace_tag {\
color: #b70202;\
}\
.ace-vscodelight .ace_tag.ace_punctuation{\
color: blue;\
}\
.ace-vscodelight .ace_attribute-name {\
color: red;\
}\
.ace-vscodelight .ace_string.ace_regex {\
color: blue;\
}\
.ace-vscodelight .ace_marker-layer .ace_selection {\
background: rgb(181, 213, 255);\
}\
.ace-vscodelight.ace_multiselect .ace_selection.ace_start {\
box-shadow: 0 0 3px 0px white;\
border-radius: 2px;\
}\
.ace-vscodelight .ace_marker-layer .ace_step {\
background: rgb(252, 255, 0);\
}\
.ace-vscodelight .ace_marker-layer .ace_stack {\
background: rgb(164, 229, 101);\
}\
.ace-vscodelight .ace_marker-layer .ace_bracket {\
margin: -1px 0 0 -1px;\
border: 1px solid rgb(192, 192, 192);\
}\
.ace-vscodelight .ace_marker-layer .ace_active-line {\
background: rgba(0, 0, 0, 0.07);\
}\
.ace-vscodelight .ace_gutter-active-line {\
background-color: #eee;\
}\
.ace-vscodelight .ace_marker-layer .ace_selected-word {\
background: red;\
border: 1px solid rgb(200, 200, 250);\
}\
.ace-vscodelight .ace_heading {\
color: #800000;\
font-weight: bold;\
}\
.ace-vscodelight .ace_list {\
color: #000;\
}\
.ace-vscodelight .ace_markup.ace_list {\
color: #0451A5\
}\
.ace-vscodelight .ace_strong {\
font-weight: bold !important;\
}\
.ace-vscodelight .ace_markup.ace_strong,.ace-vscodelight .ace_string.ace_strong {\
color: #000080;\
}\
.ace-vscodelight .ace_emphasis {\
font-style: italic;\
}";

var dom = require("../lib/dom");
dom.importCssString(exports.cssText, exports.cssClass);
});
                (function() {
                    window.require(["ace/theme/vscodelight"], function(m) {
                        if (typeof module == "object" && typeof exports == "object" && module) {
                            module.exports = m;
                        }
                    });
                })();
            