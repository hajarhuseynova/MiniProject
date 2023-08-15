const minus = document.getElementById("minus");
const pilus = document.getElementById("pilus");
const inputValue = document.getElementById("countInput");

minus.addEventListener("click", () => {
  if (inputValue.value > 0) {
    inputValue.value = parseInt(inputValue.value) - 1;
  }
});

pilus.addEventListener("click", () => {
  inputValue.value = parseInt(inputValue.value) + 1;
});

function increaseLike(element) {
  var likeCountElement = element.nextElementSibling;
  var currentLikeCount = parseInt(likeCountElement.textContent);
  likeCountElement.textContent = currentLikeCount + 1;
}

function decreaseDislike(element) {
  var dislikeCountElement = element.nextElementSibling;
  var currentDislikeCount = parseInt(dislikeCountElement.textContent);

  if (currentDislikeCount > 0) {
    dislikeCountElement.textContent = currentDislikeCount - 1;
  }
}
