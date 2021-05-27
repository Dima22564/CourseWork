/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.products = data
}

export function add (state, data) {
  state.products.push(data)
}
