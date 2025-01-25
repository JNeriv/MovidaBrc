window.ShowDialog = () => {
    var dialog = document.getElementById('my-dialog');
    if (dialog) {
        dialog.showModal();  // Muestra el diálogo
    }
};
