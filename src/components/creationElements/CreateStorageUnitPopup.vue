<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit.prevent="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="name"
        label="Название"
        hint="Название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="fullName"
        label="Полное название"
        hint="Полное название"
        dense
      />

      <q-input
        filled
        v-model="code"
        label="Код"
        hint="Код"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="internationalAbbreviation"
        label="Код"
        hint="Код"
        dense
      />

      <q-select
        filled
        dense
        v-model="measuredValueType"
        :options="measuredValueTypes"
        label="MeasuredValueType"
        option-value="id"
        option-label="name"
      />

      <div>
        <q-btn label="Создать" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  name: 'CreateStorageUnitPopup',
  data: () => {
    return {
      name: null,
      fullName: null,
      internationalAbbreviation: null,
      code: null,
      measuredValueType: null,
      measuredValueTypes: [{ name: 'Объем', id: 'Volume' }]
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.name = null
      this.fullName = null
      this.code = null
      this.internationalAbbreviation = null
      this.measuredValueType = null
    }
  }
}
</script>
