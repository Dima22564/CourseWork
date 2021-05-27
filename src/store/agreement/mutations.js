/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.agreements = data
}

export function add (state, data) {
  state.agreements.push(data)
}
