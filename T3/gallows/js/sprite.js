// $(function() {
//     var sprite = createSprite(".sprite");

//     setInterval(function () {
//         sprite.nextFrame();
//     }, 500);
// });

var createSprite = function(sprite){
    //Minha solução:
    // $(sprite).addClass("frame1");
    // return {
    //     sprite: $(sprite),
    //     frameAtual: 1,
    //     nextFrame: function() {
    //         if (this.frameAtual === 9) return; 
    //         this.sprite.removeClass("frame" + this.frameAtual);
    //         this.frameAtual++;
    //         this.sprite.addClass("frame" + this.frameAtual);
    //     }
    // }
    //Solução do professor:
    var moveFrame = function(from, to) {
        $elemento.removeClass(from)
                 .addClass(to);
    };

    var hasNext = function() {
        return current + 1 <= last;
    };

    var nextFrame = function() {
        if (hasNext()) moveFrame(frames[current], frames[++current]);
    };

    var reset = function() {
        moveFrame(frames[current],frames[current = 0]);
        
    };

    var isFinished = function() {
        return !hasNext();
    };
    
    var $elemento = $(sprite);

    var frames = ['frame1', 'frame2', 'frame3', 'frame4', 'frame5',
                  'frame6', 'frame7', 'frame8', 'frame9'];

    var current = 0;
    var last = frames.length-1;

    $elemento.addClass(frames[current]);

    return {
        nextFrame: nextFrame,
        reset: reset,
        isFinished: isFinished
    }
};