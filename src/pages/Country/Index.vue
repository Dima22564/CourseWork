<template>
  <q-page padding>
    <div>
      <q-item
        clickable
        tag="a"
        to="/country/add"
      >
        <q-item-section>
          <q-item-label>Добавить страну</q-item-label>
        </q-item-section>
      </q-item>
      <q-item
        clickable
        tag="a"
        to="/country/all"
      >
        <q-item-section>
          <q-item-label>Посмотреть все</q-item-label>
        </q-item-section>
      </q-item>
    </div>

  </q-page>
</template>

<script>
export default {
  name: 'PageCountry'
}
</script>
