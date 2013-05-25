pang_game_source
================

Нашата семинарска работа е имплементација на играта Pang_.
Pang е една стара игра за прв пат развиена уште во 1983 од едена Јапонска развивачка фирма Hudson Soft која била именувана под името Cannon Ball, а после низ годините била ре-имплеменитрана и била именувана Pang, име под кое до денес е познато.
Функционалностите на играта Pang_ која ние ја развивме преку ова семинарска работа се сосема исти со веќе постоечката Pang игра.
Играта се игра од еден играч кој треба да стигне до одредено место но по патот има препреки односно топчиња кои ако го допират го убиваат.
За таа цел тој треба да ги испука сите топчиња бројот на кои се зголемува се повеќе играчот (херојот) се приближува до крајната цел. За да помине одредено растојани(level 1-2-3...) тој мора да ги испука сите топчиња предвидени за тоа растојаније. Со секое погодување на топката ,таа се дели на половина се додека не стане многу мала и да се испука. Истотака со секое погодување на топката играчот добиа поени, а има и бонус кое паѓа од небото случајно кое истотака дава поени.Ако бонусот е бомба и ако играчотго го зема, како резултат ќе се испукаат сите топчиња до најмалата можна форма.Ако бонусот е две стрелки тогаш играчот ќе може да испука две стрелки истовремено.
За да го имплементираме во код играта која го објаснивме погоре во повеќето случаи користиме класи. Човекот е претставен со една класа именувана Hero,топките истотака се претставени во една класа именуван Ball,и после за чување на повеќе топки користиме листа од топки. Истотака во една датотека чуваме и листа од 5 најдобриме играчи сортирани во опаѓачки редослед.
Сега ќе ja објаснам класата Hero и две функции кои мислам дека се побитни.
Во класата Hero чуваме кординати каде се наоѓа играчот во моментот.Со секо предвижување надесно или налево X кординатата ја зголемуваме односно ја намалуваме додека Y кординатата е фиксна.Во ова класа чуваме и една инстанца од класата Image референцата на која ја поставуваме да биде сликата на херојот.Истотака има и уште една метода drawtheImg(Graphics g):void со која ја исртуваме сликата на околината проследена како аргумент на функцијата.
Методот splitTheBall(Ball) се повикува кога играчот ќе ја погоди топката.Во овој метод топката проследен како аргумент на функцијата се брише од листата со топки и се додаваат две нови топки со големина половина од погодената топка и со спротивни насоки на предвижување.
Методот explodeTheBalls() се повикува ако падне бонус бомба и истиот играчот го зема.Во овој метод се ажурира сите топки и ако постои топка со поголема од минималната големина на топката се повикува методот splitTheBall(Ball). Листата се ажурира се додека сите топки се со минимален радиус.
Човекот се предвижува со стрелките лево односно десно а се испука со копчето space.
