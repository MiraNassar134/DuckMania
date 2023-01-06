mergeInto(LibraryManager.library, {
  closeWindow: function () {
    window.top.close();
    window.close();
  },
});
