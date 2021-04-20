<template>
  <q-page padding>
    <div>
      <q-item
        clickable
        tag="a"
        to="/currency/add"
      >
        <q-item-section>
          <q-item-label>Добавить валюту</q-item-label>
        </q-item-section>
      </q-item>
      <q-item
        clickable
        tag="a"
        to="/currency/all"
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
  name: 'PageCurrency'
}
</script>
