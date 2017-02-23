var base = '[PropertySubtype/PropertyTypeDescription] [Rooms] hab y [Surface] m2 en [Zone]';
var endSingle = ', ¡date prisa!';
var endMultiple = ' y más novedades, ¡date prisa!';
var subject;
var propertyTypeDescription = matches.Get(0).PropertyTypeDescription;
if (matches.Get(0).PropertySubtype > 0) {
    propertyTypeDescription = matches.Get(0).PropertySubtypeDescription;
}
subject = base.replace('[PropertySubtype/PropertyTypeDescription]', propertyTypeDescription);
if (matches.Get(0).Rooms > 0) {
    subject = subject.replace('[Rooms]', matches.Get(0).Rooms);
} else {
    subject = subject.replace(' [Rooms] hab y', '');
}
if (matches.Get(0).Surface > 0) {
    subject = subject.replace('[Surface]', matches.Get(0).Surface);
} else {
    if (matches.Get(0).Rooms > 0) {
        subject = subject.replace(' y [Surface] m2', '');
    } else {
        subject = subject.replace(' [Surface] m2', '');
    }
}
subject = subject.replace('[Zone]', matches.Get(0).Zone);
if (matches.Count() > 1) {
    subject = subject + endMultiple;
} else {
    subject = subject + endSingle;
}
return subject;