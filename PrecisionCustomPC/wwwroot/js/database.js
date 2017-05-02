var CaseSize;
var Case;
var CPU;
$(document).ready(function(){
    $('ul.size-option').click(function(event) {
        Flicker($(this));
    });
    
});

function Flicker(option) {
    CaseSize = option.attr('rel');
}