<template>
  <q-page padding>
    <div>
      <q-item
        clickable
        tag="a"
        to="/company/add"
      >
        <q-item-section>
          <q-item-label>Добавить компанию</q-item-label>
        </q-item-section>
      </q-item>
      <q-item
        clickable
        tag="a"
        to="/company/all"
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
  name: 'IndexPageCompany'
}
</script>
