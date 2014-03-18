(
function (doc) {
    if (doc.quantity) {
        emit(doc._id, doc.quantity);
    }
}
)